﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Melia.Shared.Data.Database;
using Melia.Shared.ObjectProperties;
using Melia.Zone.Scripting;

namespace Melia.Zone.World.Quests
{
	/// <summary>
	/// Represents a quest that was taken on by a character.
	/// </summary>
	public class Quest
	{
		private static long Ids = ObjectIdRanges.Quests;

		private readonly List<QuestProgress> _progresses = new List<QuestProgress>();
		private readonly Dictionary<string, QuestProgress> _indexedProgresses = new Dictionary<string, QuestProgress>();

		/// <summary>
		/// Returns the quest's globally unique object id.
		/// </summary>
		/// <remarks>
		/// The game's quests might or might not have object ids,
		/// but ours do, since we need to be able to identify
		/// them in case of a player having one quest multiple
		/// times.
		/// </remarks>
		public long ObjectId { get; } = Interlocked.Increment(ref Ids);

		/// <summary>
		/// Returns the quest's object id as a hex string.
		/// </summary>
		public string ObjectIdStr => "0x" + this.ObjectId.ToString("X16");

		/// <summary>
		/// Gets or sets the quest's current status.
		/// </summary>
		public QuestStatus Status { get; set; }

		/// <summary>
		/// Gets or sets the time at which the quest is started and
		/// added to the character's quest log.
		/// </summary>
		public DateTime StartTime { get; set; }

		/// <summary>
		/// Gets or sets the time at which this quest was completed.
		/// </summary>
		public DateTime CompleteTime { get; set; }

		/// <summary>
		/// Returns the quest's data.
		/// </summary>
		public QuestData Data { get; }

		/// <summary>
		/// Returns the quest's static data.
		/// </summary>
		public QuestStaticData QuestStaticData { get; private set; }

		/// <summary>
		/// Returns the quest's session object data.
		/// </summary>
		public SessionObjectData SessionObjectStaticData { get; private set; }

		/// <summary>
		/// Returns a list with the quest's objectives' progresses.
		/// </summary>
		public ReadOnlyCollection<QuestProgress> Progresses => _progresses.AsReadOnly();

		/// <summary>
		/// Returns progress value of the quest's objectives with a shared objective id.
		/// </summary>
		public int ProgressValue(int objectiveId) => Progresses.Sum(a => a.Objective.Id == objectiveId ? a.Count : 0);

		/// <summary>
		/// Returns progress count of the quest's objectives with a shared objective id.
		/// </summary>
		public int ProgressCount(int objectiveId) => Progresses.Sum(a => a.Objective.Id == objectiveId ? 1 : 0);

		/// <summary>
		/// Returns true if all of the quest's objectives were completed.
		/// </summary>
		public bool ObjectivesCompleted => this.Progresses.All(a => a.Done);

		/// <summary>
		/// Returns true if the quest is currently in progress.
		/// </summary>
		public bool InProgress => this.Status >= QuestStatus.Progress && this.Status < QuestStatus.Complete;

		/// <summary>
		/// Returns true if the quest is possible.
		/// </summary>
		public bool IsPossible => this.Status > QuestStatus.Impossible && this.Status < QuestStatus.Progress;

		/// <summary>
		/// Returns true if the quest is able to be completed.
		/// </summary>
		public bool IsCompletable => this.ObjectivesCompleted && this.Status < QuestStatus.Complete;

		/// <summary>
		/// Gets or sets whether any objectives' progresses changed during
		/// the last objectives update.
		/// </summary>
		public bool ChangesOnLastUpdate { get; set; }

		/// <summary>
		/// Creates new quest.
		/// </summary>
		/// <param name="questData"></param>
		public Quest(QuestData questData)
		{
			this.Data = questData;

			this.InitProgresses();
			this.InitialUnlock();

			Load();
		}

		/// <summary>
		/// Load Static Data from Database
		/// </summary>
		private void Load()
		{
			this.QuestStaticData = ZoneServer.Instance.Data.QuestDb.Find(this.Data.Id);
			this.SessionObjectStaticData = ZoneServer.Instance.Data.SessionObjectDb.Find(this.QuestStaticData.QuestSSN);
		}

		/// <summary>
		/// Creates quest from given id.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">
		/// Thrown if no quest with the given id could be found.
		/// </exception>
		public static Quest Create(int questId)
		{
			if (!QuestScript.TryGet(questId, out var questScript))
				throw new ArgumentException($"Quest '{questId}' not found.");

			var result = new Quest(questScript.Data);
			return result;
		}

		/// <summary>
		/// Initializes the quest's progresses based on its data.
		/// </summary>
		private void InitProgresses()
		{
			foreach (var objective in this.Data.Objectives)
			{
				var progress = new QuestProgress(objective);
				_progresses.Add(progress);
				_indexedProgresses[objective.Ident] = progress;
			}
		}

		/// <summary>
		/// Returns the progress for the objective with the given identifier
		/// via out. Returns false if the objective wasn't found.
		/// </summary>
		/// <param name="ident"></param>
		/// <returns></returns>
		public bool TryGetProgress(string ident, out QuestProgress progress)
		{
			return _indexedProgresses.TryGetValue(ident, out progress);
		}

		/// <summary>
		/// Locks and unlocks objectives based on the quest's unlock type.
		/// </summary>
		public void InitialUnlock()
		{
			if (this.Data.UnlockType == QuestUnlockType.AllAtOnce)
			{
				_progresses.ForEach(a => a.Unlocked = true);
			}
			else
			{
				_progresses.ForEach(a => a.Unlocked = false);
				if (_progresses.Any())
					_progresses[0].Unlocked = true;
			}
		}

		/// <summary>
		/// Unlocks objectives based on which objectives have been completed
		/// if this quest uses sequential unlocking.
		/// </summary>
		public void UpdateUnlock()
		{
			if (this.Data.UnlockType != QuestUnlockType.Sequential)
				return;

			for (var i = 0; i < _progresses.Count - 1; ++i)
			{
				if (_progresses[i].Done)
					_progresses[i + 1].Unlocked = true;
				else
					break;
			}
		}

		/// <summary>
		/// Iterates over the quest's objectives and runs the given function
		/// on all objectives with the given type. If any progresses changed,
		/// the ChangesOnLastUpdate property will be true.
		/// </summary>
		/// <typeparam name="TObjective"></typeparam>
		/// <param name="updater"></param>
		public void UpdateObjectives<TObjective>(QuestObjectivesUpdateFunc<TObjective> updater) where TObjective : QuestObjective
		{
			var quest = this;
			var anythingChanged = false;

			for (var j = 0; j < quest.Progresses.Count; j++)
			{
				var progress = quest.Progresses[j];
				if (!progress.Unlocked)
					continue;

				if (!(progress.Objective is TObjective tObjective))
					continue;

				var count = progress.Count;
				var done = progress.Done;
				var unlocked = progress.Unlocked;

				updater(this, tObjective, progress);

				if (progress.Count != count || progress.Done != done || progress.Unlocked != unlocked)
					anythingChanged = true;
			}

			this.ChangesOnLastUpdate = anythingChanged;
		}

		/// <summary>
		/// Iterates over the quest's modifiers and runs the given function
		/// on all modifiers with the given type. If any progresses changed,
		/// the ChangesOnLastUpdate property will be true.
		/// </summary>
		/// <typeparam name="TModifier"></typeparam>
		/// <param name="updater"></param>
		public void UpdateModifiers<TModifier>(QuestModifiersUpdateFunc<TModifier> updater) where TModifier : QuestModifier
		{
			var quest = this;
			var anythingChanged = false;

			for (var j = 0; j < quest.Progresses.Count; j++)
			{
				var progress = quest.Progresses[j];
				if (!progress.Unlocked)
					continue;

				var count = progress.Count;
				var done = progress.Done;
				var unlocked = progress.Unlocked;

				for (var i = 0; i < quest.Data.Modifiers.Count; i++)
				{
					var modifier = quest.Data.Modifiers[i];
					if (modifier is not TModifier tModifier)
						continue;
					updater(this, tModifier, progress);
				}

				if (progress.Count != count || progress.Done != done || progress.Unlocked != unlocked)
					anythingChanged = true;
			}

			this.ChangesOnLastUpdate = anythingChanged;
		}

		/// <summary>
		/// Marks all of the quest's objectives as done.
		/// </summary>
		public void CompleteObjectives()
		{
			foreach (var progress in this.Progresses)
				progress.SetDone();
		}
	}

	/// <summary>
	/// A function used to update a quest's objectives.
	/// </summary>
	/// <typeparam name="TObjective"></typeparam>
	/// <param name="quest"></param>
	/// <param name="objective"></param>
	/// <param name="progress"></param>
	public delegate void QuestObjectivesUpdateFunc<in TObjective>(Quest quest, TObjective objective, QuestProgress progress) where TObjective : QuestObjective;

	/// <summary>
	/// A function used to update a quest's modifiers.
	/// </summary>
	/// <typeparam name="TModifier"></typeparam>
	/// <param name="quest"></param>
	/// <param name="modifier"></param>
	/// <param name="progress"></param>
	public delegate void QuestModifiersUpdateFunc<in TModifier>(Quest quest, TModifier modifier, QuestProgress progress) where TModifier : QuestModifier;

	/// <summary>
	/// Specifies a quest's current status.
	/// </summary>
	public enum QuestStatus
	{
		/// <summary>
		/// When quest is reset due to rank reset.
		/// </summary>
		RankReset = -10000,

		/// <summary>
		/// The "system" cancelled the quest
		/// </summary>
		SystemCancel = -1000,

		/// <summary>
		/// The quest hasn't been started yet and the character can't
		/// receive it.
		/// </summary>
		Impossible = -200,

		/// <summary>
		/// The quest was failed.
		/// </summary>
		Failed = -100,

		/// <summary>
		/// The quest was given up.
		/// </summary>
		Abandoned = -10,

		/// <summary>
		/// The quest hasn't been started yet and the character has yet
		/// to actually receive it.
		/// </summary>
		Possible = 0,

		/// <summary>
		/// The quest has been restarted after being abandoned
		/// </summary>
		Restarted = 1,

		/// <summary>
		/// The quest is currently in progress.
		/// </summary>
		Progress = 100,

		/// <summary>
		/// The quest objectives are met.
		/// </summary>
		Success = 200,

		/// <summary>
		/// The quest was completed successfully.
		/// </summary>
		Complete = 300,
	}
}
