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

[TrackScript("EP13_2_DPRISON1_MQ_9_TRACK_1")]
public class EP132DPRISON1MQ9TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_9_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(-1088.99,423.58,1424.19);
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
			case 3:
				break;
			case 16:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_blue5", "skl_eff_magicblock", "F_only_quest_smoke141_darkblue_spread_out", "skl_eff_shot_smoke", "FAST", 30, 1, 0, 0, 10, 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke010_blue3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_out026_blue3", "BOT", 0);
				break;
			case 42:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG1");
				break;
			case 43:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG2");
				break;
			case 44:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG3");
				break;
			case 45:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG4");
				break;
			case 46:
				//DRT_RUN_FUNCTION("SCR_MQ9_TRACK_HEADICON_1");
				break;
			case 59:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_light004_violet_dark", "skl_eff_magicblock", "F_only_quest_smoke141_darkblue_spread_out", "skl_eff_shot_smoke", "FAST", 80, 1, 0, 0, 10, 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_lineup018_dark1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke001_dark_2", "MID", 0);
				break;
			case 82:
				//DRT_ACTOR_ATTACH_EFFECT("F_only_quest_burstup047_red", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground172_dark", "BOT", 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup045_violet2", "BOT", 0);
				//DRT_CLEAR_EFFECT();
				break;
			case 94:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG5");
				break;
			case 102:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_9_DLG6");
				break;
			case 109:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_9_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
