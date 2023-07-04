using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Tracks;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Util;

namespace Melia.Zone.World.Actors.Characters.Components
{
	public class TrackComponent : CharacterComponent
	{
		public Track ActiveTrack { get; private set; }

		public TrackComponent(Character character) : base(character)
		{
		}

		public void End(string trackId)
		{
			if (this.ActiveTrack != null && this.ActiveTrack.Id != trackId)
				return;

			//if (TrackScripts.TryGet(trackId, out var trackScript))
			//	trackScript.OnComplete(this.Character, this.ActiveTrack);

			this.ActiveTrack = null;
		}

		/// <summary>
		/// Starts the given quest, adding it to the character's quest log.
		/// </summary>
		/// <param name="track"></param>
		/// <returns></returns>
		public bool Start(Track track)
		{
			if (track.StartTime == DateTime.MinValue)
				track.StartTime = DateTime.Now;

			track.Dialog = new Dialog(this.Character, null);
			this.ActiveTrack = track;

			Actor[] entities;
			//if (TrackScripts.TryGet(track.Id, out var trackScript))
			//entities = trackScript.OnStart(this.Character, this.ActiveTrack);
			//else
			entities = new Actor[0];
			track.Actors = entities;
			Send.ZC_NORMAL.SetupCutscene(this.Character, true, false, true);
			Send.ZC_NORMAL.LoadCutscene(this.Character, 0x77, true, track.Id);
			Send.ZC_NORMAL.LoadCutscene(this.Character, 0x6B, true, this.Character.Name);
			Send.ZC_NORMAL.StartCutscene(this.Character, track.Id, entities);

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
			if (TrackScripts.TryGet(trackId, out var trackScript))
			{
				this.ActiveTrack.Frame = frame;
				//Task.FromResult(trackScript.OnProgress(this.Character, track, frame));
				return true;
			}

			return false;
		}
	}
}
