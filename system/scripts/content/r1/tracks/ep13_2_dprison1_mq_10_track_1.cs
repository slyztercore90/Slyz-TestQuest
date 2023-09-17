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

[TrackScript("EP13_2_DPRISON1_MQ_10_TRACK_1")]
public class EP132DPRISON1MQ10TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_10_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(-1214.36,408.70,1426.20);
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
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_warrior_skyline_shot_Highlander01_3", "MID", 0);
				break;
			case 22:
				//DRT_RUN_FUNCTION("SCR_MQ10_TRACK_ADDBUFF");
				//DRT_ACTOR_ATTACH_EFFECT("F_only_quest_rize022_ground_dark_loop", "BOT");
				break;
			case 33:
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke186_dark", "BOT", 0);
				break;
			case 70:
				//DRT_CLEAR_EFFECT();
				break;
			case 74:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG1");
				break;
			case 77:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG9");
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion123_dark", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force107_dark", "mon_dark_spirit_blow", "F_only_quest_smoke068_dark", "None", "FAST", 200, 0, 0, 0, 0, 0);
				break;
			case 82:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow005_mash2", "arrow_cast", "F_only_quest_explosion078_dark", "arrow_blow", "FAST", 300, 0, 0, 1, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_levitation015_dark", "BOT", 0);
				break;
			case 102:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG2");
				break;
			case 103:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG3");
				break;
			case 104:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG4");
				break;
			case 105:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG5");
				break;
			case 117:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG6");
				break;
			case 118:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG7");
				break;
			case 119:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG8");
				break;
			case 128:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup006_dark", "BOT", 0);
				break;
			case 132:
				//DRT_CLEAR_EFFECT();
				break;
			case 151:
				//DRT_RUN_FUNCTION("SCR_MQ10_TRACK_ADDBUFF");
				break;
			case 153:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
