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

[TrackScript("EP13_F_SIAULIAI_3_MQ_04_TRACK")]
public class EP13FSIAULIAI3MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_MQ_04_TRACK");
		//SetMap("ep13_f_siauliai_3");
		//CenterPos(823.50,271.21,-251.07);
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
			case 40:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 41:
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 59:
				//DRT_RUN_FUNCTION("SCR_EP13_F_SIAULIAI_3_MQ_07_TRACK_DAYLIGHT_SET1");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_spread_in032_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_explosion128_white", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_levitation033_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "BOT");
				break;
			case 78:
				//DRT_RUN_FUNCTION("SCR_EP13_F_SIAULIAI_3_MQ_07_TRACK_DAYLIGHT_CLEAR");
				break;
			case 95:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T1");
				break;
			case 96:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T2");
				break;
			case 97:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T3");
				break;
			case 100:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				break;
			case 102:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "BOT");
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 104:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 107:
				//DRT_ACTOR_PLAY_EFT("F_light018_yellow", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				break;
			case 108:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T4");
				break;
			case 109:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T5");
				break;
			case 110:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T6");
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 125:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_3_MQ_04_DLG_T7", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
