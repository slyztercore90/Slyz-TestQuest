using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP13_2_DPRISON2_MQ_1_TRACK_1")]
public class EP132DPRISON2MQ1TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON2_MQ_1_TRACK_1");
		//SetMap("ep13_2_d_prison_2");
		//CenterPos(1835.91,218.46,91.38);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		return Array.Empty<IActor>();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG1");
				break;
			case 9:
				break;
			case 15:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ1_TRACK_HEADICON_1");
				break;
			case 20:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG2");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke013_blue_smoke", "MID", 0);
				break;
			case 35:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG3");
				break;
			case 36:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG4");
				break;
			case 37:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG5");
				break;
			case 38:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG6");
				break;
			case 39:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG7");
				break;
			case 40:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG8");
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_1_TRACK_DLG9");
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
