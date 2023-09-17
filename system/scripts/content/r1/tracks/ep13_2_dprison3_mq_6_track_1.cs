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

[TrackScript("EP13_2_DPRISON3_MQ_6_TRACK_1")]
public class EP132DPRISON3MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(-133.00,10.10,829.77);
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
			case 10:
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow008", "arrow_cast", "F_only_quest_spark013", "arrow_blow", "FAST", 1000, 0, 0, 1, 0, 0);
				break;
			case 35:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG1");
				break;
			case 36:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG2");
				break;
			case 37:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG3");
				break;
			case 38:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG4");
				break;
			case 39:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG5");
				break;
			case 40:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG6");
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG7");
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "MID", 0);
				break;
			case 58:
				break;
			case 64:
				break;
			case 77:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_6_MGAME_1");
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
