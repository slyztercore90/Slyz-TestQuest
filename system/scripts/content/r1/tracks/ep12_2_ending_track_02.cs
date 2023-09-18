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

[TrackScript("EP12_2_ENDING_TRACK_02")]
public class EP122ENDINGTRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_02");
		//SetMap("d_dcapital_108");
		//CenterPos(474.23,23.86,1992.44);
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
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_explosion024_rize", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_spread_in001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark2", "MID", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_explosion099_dark", "BOT", 0);
				break;
			case 34:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_SET");
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_05");
				//DRT_ACTOR_PLAY_EFT("F_rize006_red ", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 46:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_5");
				break;
			case 47:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_6");
				break;
			case 48:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_7");
				break;
			case 49:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_8");
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 57:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_9");
				break;
			case 58:
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				break;
			case 89:
				break;
			case 92:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ17_DLG_7", 3);
				break;
			case 96:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 97:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 98:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_CLEAR");
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 99:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_item_drop_line_loop_white", "BOT");
				//DRT_ACTOR_PLAY_EFT("I_harfsphere002_blue", "BOT", 0);
				break;
			case 100:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 101:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 102:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 103:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 104:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 105:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 106:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 107:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 108:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 109:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 110:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 111:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 112:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 113:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 114:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_ACTOR_PLAY_EFT("I_harfsphere002_blue", "BOT", 0);
				break;
			case 115:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 139:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke034_white", "skl_eff_whitetigerhowling_cast", "F_ground012_light", "skl_holylight", "FAST", 50, 1, 0, 1, 0, 0);
				break;
			case 150:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_10");
				break;
			case 151:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 156:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 161:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_1");
				break;
			case 162:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_2");
				break;
			case 163:
				//DRT_ACTOR_ATTACH_EFFECT("F_light003_yellow", "MID");
				break;
			case 165:
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 167:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_3");
				break;
			case 179:
				//DRT_PLAY_MGAME("EP12_2_ENDING_MINI_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
