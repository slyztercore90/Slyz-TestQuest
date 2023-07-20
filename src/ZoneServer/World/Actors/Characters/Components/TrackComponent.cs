using System;
using System.Threading.Tasks;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Tracks;

namespace Melia.Zone.World.Actors.Characters.Components
{
	public class TrackComponent : CharacterComponent
	{
		public Track ActiveTrack { get; private set; }

		public TrackComponent(Character character) : base(character)
		{
		}

		/// <summary>
		/// Start a track.
		/// </summary>
		/// <param name="trackId"></param>
		/// <returns></returns>
		public bool Start(string trackId)
		{
			if (!this.Character.EyesOpen)
				return false;
			if (this.ActiveTrack != null)
				return false;

			var track = Track.Create(trackId);
			track.Status = TrackStatus.Started;
			track.Dialog = new Dialog(this.Character, null);
			this.ActiveTrack = track;

			IActor[] actors;
			if (TrackScript.TryGet(track.Id, out var trackScript))
				actors = trackScript.OnStart(this.Character, this.ActiveTrack);
			else
				actors = Array.Empty<Actor>();
			track.Actors = actors;

			Send.ZC_NORMAL.SetupCutscene(this.Character, true, false, true);
			Send.ZC_NORMAL.LoadCutscene(this.Character, 0x77, true, track.Id);
			Send.ZC_NORMAL.LoadCutscene(this.Character, 0x6B, true, this.Character.Name);
			Send.ZC_NORMAL.StartCutscene(this.Character, track.Id, actors);

			return true;
		}

		/// <summary>
		/// Progress through a track
		/// </summary>
		/// <param name="trackId"></param>
		/// <param name="frame"></param>
		/// <returns></returns>
		public bool Progress(string trackId, int frame)
		{
			if (TrackScript.TryGet(this.ActiveTrack.Data.Id, out var trackScript))
			{
				this.ActiveTrack.Frame = frame;
				Task.FromResult(trackScript.OnProgress(this.Character, this.ActiveTrack, frame));
				return true;
			}

			return false;
		}

		/// <summary>
		/// End a track.
		/// </summary>
		/// <param name="trackId"></param>
		public void End(string trackId)
		{
			if (this.ActiveTrack != null && this.ActiveTrack.Id != trackId)
				return;

			if (TrackScript.TryGet(trackId, out var trackScript))
				trackScript.OnComplete(this.Character, this.ActiveTrack);

			this.ActiveTrack = null;
		}

		/// <summary>
		/// Cancel a track.
		/// </summary>
		public void Cancel()
		{
			if (this.ActiveTrack == null)
				return;

			if (TrackScript.TryGet(this.ActiveTrack.Id, out var trackScript))
				trackScript.OnCancel(this.Character, this.ActiveTrack);

			this.ActiveTrack = null;
		}
	}
}
