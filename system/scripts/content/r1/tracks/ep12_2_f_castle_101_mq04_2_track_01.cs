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

[TrackScript("EP12_2_F_CASTLE_101_MQ04_2_TRACK_01")]
public class EP122FCASTLE101MQ042TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ04_2_TRACK_01");
		//SetMap("None");
		//CenterPos(-1494.80,52.93,-350.71);
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
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_5");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				break;
			case 54:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				break;
			case 68:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_6");
				break;
			case 69:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_7");
				break;
			case 78:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
