using System;
using System.Collections.Generic;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.MiniGames;
using Melia.Zone.World.Quests;
using Yggdrasil.Scripting;

namespace Melia.Zone.Scripting
{
	/// <summary>
	/// A script that sets up and manages a minigame.
	/// </summary>
	public abstract class MiniGameScript : IScript, IDisposable
	{
		private readonly static object ScriptsSyncLock = new object();
		private readonly static Dictionary<string, MiniGameScript> Scripts = new Dictionary<string, MiniGameScript>();
		private readonly static Dictionary<Type, QuestObjective> Objectives = new Dictionary<Type, QuestObjective>();

		/// <summary>
		/// Returns this script's minigame data.
		/// </summary>
		public MiniGameData Data { get; } = new MiniGameData();

		/// <summary>
		/// Returns the id of the minigame this script created.
		/// </summary>
		public string MiniGameId => this.Data.Id;

		/// <summary>
		/// Initializes script, creating the minigame and saving it for
		/// later use.
		/// </summary>
		/// <returns></returns>
		public bool Init()
		{
			this.Load();

			lock (ScriptsSyncLock)
			{
				Scripts[this.Data.Id] = this;
			}

			return true;
		}

		/// <summary>
		/// Returns the minigame script with the given id via out, returns
		/// false if no script was found.
		/// </summary>
		/// <param name="mGameId"></param>
		/// <param name="mGameScript"></param>
		/// <returns></returns>
		public static bool TryGet(string mGameId, out MiniGameScript mGameScript)
		{
			lock (ScriptsSyncLock)
				return Scripts.TryGetValue(mGameId, out mGameScript);
		}

		/// <summary>
		/// Cleans up saved tracks and objectives.
		/// </summary>
		public void Dispose()
		{
			// Unload and remove all objectives that were saved for checking
			// whether they were done when even one minigame script is disposed.
			// The only way minigame scripts are gonna be disposed is if we
			// reload all of them, so it doesn't matter if we remove them
			// all at once, and this way we don't have to worry about
			// managing which script should unload which objective.
			lock (ScriptsSyncLock)
			{
				if (Objectives.Count == 0)
					return;

				foreach (var objective in Objectives.Values)
					objective.Unload();

				Objectives.Clear();
			}
		}

		/// <summary>
		/// Called during initialization to set the minigame's values.
		/// </summary>
		protected abstract void Load();

		/// <summary>
		/// Sets the minigame's id.
		/// </summary>
		/// <param name="id"></param>
		protected void SetId(string id)
			=> this.Data.Id = id;

		/// <summary>
		/// Sets the delay for automatically received tracks, between
		/// meeting the prerequisites and the start of the minigame.
		/// </summary>
		/// <param name="startDelay"></param>
		protected void SetDelay(TimeSpan startDelay)
			=> this.Data.StartDelay = startDelay;

		/// <summary>
		/// Called when a character starts this minigame.
		/// </summary>
		/// <remarks>
		/// Called before the minigame is added to the minigame log, allowing
		/// for changes of its initial progress.
		/// </remarks>
		public virtual IActor[] OnStart(Character character, MiniGame minigame)
		{
			character.StartLayer();
			return Array.Empty<IActor>();
		}

		/// <summary>
		/// Called when a character completes this minigame successfully.
		/// </summary>
		/// <remarks>
		/// Called after the minigame was marked as completed.
		/// </remarks>
		public virtual void OnComplete(Character character, MiniGame minigame)
		{
			character.StopLayer();
			foreach (var actor in minigame.Actors)
			{
				if (actor != character && actor is IMonster monster)
					character.Map.RemoveMonster(monster);
			}
		}

		/// <summary>
		/// Called when a character gives up this minigame.
		/// </summary>
		/// <remarks>
		/// Called after the minigame was marked as cancelled.
		/// </remarks>
		public virtual void OnCancel(Character character, MiniGame minigame)
		{
			character.StopLayer();

			if (minigame.Actors != null)
			{
				foreach (var actor in minigame.Actors)
				{
					if (actor != character && actor is IMonster monster)
						character.Map.RemoveMonster(monster);
				}
			}
		}
	}

	/// <summary>
	/// Used to define which minigame scripts handle which tracks, based on
	/// a minigame id.
	/// </summary>
	public class MiniGameScriptAttribute : Attribute
	{
		/// <summary>
		/// Returns the id of minigame script.
		/// </summary>
		public string TrackId { get; }

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="miniGameId"></param>
		public MiniGameScriptAttribute(string miniGameId)
		{
			this.TrackId = miniGameId;
		}
	}
}
