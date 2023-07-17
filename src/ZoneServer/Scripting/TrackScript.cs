using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Tracks;
using Yggdrasil.Scripting;

namespace Melia.Zone.Scripting
{
	/// <summary>
	/// A script that sets up and manages tracks.
	/// </summary>
	public abstract class TrackScript : IScript, IDisposable
	{
		private readonly static object ScriptsSyncLock = new object();
		private readonly static Dictionary<string, TrackScript> Scripts = new Dictionary<string, TrackScript>();
		private readonly static Dictionary<Type, QuestObjective> Objectives = new Dictionary<Type, QuestObjective>();

		/// <summary>
		/// Returns this script's track data.
		/// </summary>
		public TrackData Data { get; } = new TrackData();

		/// <summary>
		/// Returns the id of the track this script created.
		/// </summary>
		public string TrackId => this.Data.Id;

		/// <summary>
		/// Initializes script, creating the track and saving it for
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
		/// Returns the track script with the given id via out, returns
		/// false if no script was found.
		/// </summary>
		/// <param name="trackId"></param>
		/// <param name="trackScript"></param>
		/// <returns></returns>
		public static bool TryGet(string trackId, out TrackScript trackScript)
		{
			lock (ScriptsSyncLock)
				return Scripts.TryGetValue(trackId, out trackScript);
		}

		/// <summary>
		/// Cleans up saved tracks and objectives.
		/// </summary>
		public void Dispose()
		{
			// Unload and remove all objectives that were saved for checking
			// whether they were done when even one track script is disposed.
			// The only way track scripts are gonna be disposed is if we
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
		/// Called during initialization to set the track's values.
		/// </summary>
		protected abstract void Load();

		/// <summary>
		/// Sets the track's id.
		/// </summary>
		/// <param name="id"></param>
		protected void SetId(string id)
			=> this.Data.Id = id;

		/// <summary>
		/// Sets whether the track can be cancelled.
		/// </summary>
		/// <param name="cancelable"></param>
		protected void SetCancelable(bool cancelable)
			=> this.Data.Cancelable = cancelable;

		/// <summary>
		/// Sets the delay for automatically received tracks, between
		/// meeting the prerequisites and the start of the track.
		/// </summary>
		/// <param name="startDelay"></param>
		protected void SetDelay(TimeSpan startDelay)
			=> this.Data.StartDelay = startDelay;

		/// <summary>
		/// Called when a character receives this track.
		/// </summary>
		/// <remarks>
		/// Called before the track is added to the track log, allowing
		/// for changes of its initial progress.
		/// </remarks>
		public virtual IActor[] OnStart(Character character, Track track)
		{
			Send.ZC_SET_LAYER(character, character.Map.GetNewLayer(), true);
			return Array.Empty<IActor>();
		}

		/// <summary>
		/// Called when a character completes this track successfully.
		/// </summary>
		/// <remarks>
		/// Called after the track was marked as completed, but before
		/// it's removed from the track log and the rewards were given.
		/// </remarks>
		public virtual async Task OnProgress(Character character, Track track, int frame)
		{
			Send.ZC_NORMAL.SetTrackFrame(character, track.Frame);
			await Task.Yield();
		}

		/// <summary>
		/// Called when a character completes this track successfully.
		/// </summary>
		/// <remarks>
		/// Called after the track was marked as completed, but before
		/// it's removed from the track log and the rewards were given.
		/// </remarks>
		public virtual void OnComplete(Character character, Track track)
		{
			Send.ZC_SET_LAYER(character, 0, false);
		}

		/// <summary>
		/// Called when a character gives up this track.
		/// </summary>
		/// <remarks>
		/// Called after the track was marked as completed, but before
		/// it's removed from the track log.
		/// </remarks>
		public virtual void OnCancel(Character character, Track track)
		{
			Send.ZC_SET_LAYER(character, 0, false);
		}
	}

	/// <summary>
	/// Used to define which track scripts handle which tracks, based on
	/// a track id.
	/// </summary>
	public class TrackScriptAttribute : Attribute
	{
		/// <summary>
		/// Returns the track id of track script.
		/// </summary>
		public string TrackId { get; }

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="trackId"></param>
		public TrackScriptAttribute(string trackId)
		{
			this.TrackId = trackId;
		}
	}
}
