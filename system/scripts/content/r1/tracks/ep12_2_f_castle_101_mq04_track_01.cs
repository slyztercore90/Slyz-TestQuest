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

[TrackScript("EP12_2_F_CASTLE_101_MQ04_TRACK_01")]
public class EP122FCASTLE101MQ04TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ04_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(-939.01,52.93,-56.97);
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
			case 6:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_01");
				break;
			case 23:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_18");
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ04_DLG_21", 3);
				break;
			case 24:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_06");
				break;
			case 40:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_07");
				break;
			case 41:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_08");
				break;
			case 42:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ04_DLG_19", 4);
				break;
			case 63:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_09");
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "MID", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 74:
				break;
			case 87:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_10");
				break;
			case 88:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_03");
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("I_light007_red", "TOP", 0);
				break;
			case 96:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_11");
				break;
			case 97:
				//DRT_PLAY_FORCE(0, 1, 2, "I_light003_red", "skl_eff_rune_light", "I_light007_red", "item_drop_crystal_light", "FAST", 150, 1, 0, 0, 10, 0);
				break;
			case 102:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_03");
				break;
			case 111:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_12");
				break;
			case 112:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_13");
				break;
			case 113:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_SET");
				break;
			case 120:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_CLEAR");
				break;
			case 122:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_14");
				break;
			case 124:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "MID", 0);
				break;
			case 129:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 133:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_15");
				break;
			case 173:
				//DRT_FUNC_ACT("SCR_EP12_2_F_CASTLE_101_MQ04_TRACKINSELDLG");
				break;
			case 178:
				//DRT_ACTOR_PLAY_EFT("I_light007_red", "TOP", 0);
				break;
			case 186:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 192:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				break;
			case 202:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_16");
				break;
			case 203:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_burst_up_dark", "MID", 0);
				break;
			case 214:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
