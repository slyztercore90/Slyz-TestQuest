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

[TrackScript("EP13_F_SIAULIAI_5_MQ_04_TRACK")]
public class EP13FSIAULIAI5MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_5_MQ_04_TRACK");
		//SetMap("ep13_f_siauliai_5");
		//CenterPos(952.24,15.98,106.66);
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
			case 15:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG1");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_light134", "BOT");
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_light135", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_black3", "MID");
				break;
			case 19:
				break;
			case 23:
				break;
			case 26:
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "MID", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 42:
				break;
			case 52:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG2");
				break;
			case 54:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG3");
				break;
			case 55:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG4");
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_spread_out051", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out046", "BOT", 0);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_explosion98_blood", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_explosion98_blood", "BOT", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_explosion98_blood2", "BOT", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_explosion007_white", "MID", 0);
				break;
			case 68:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG5");
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_black3", "MID");
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_explosion001_dark", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_black3", "MID");
				//DRT_ACTOR_PLAY_EFT("I_smoke028_spread_out", "TOP", 0);
				break;
			case 80:
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_fire_whiteball", "MID");
				//DRT_CLEAR_EFFECT();
				break;
			case 93:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_rize002_red", "TOP");
				break;
			case 96:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG6");
				break;
			case 97:
				//DRT_ACTOR_PLAY_EFT("F_ground204_rotate_fire", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_red_nosound", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup005_fire", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in030_fire2", "BOT", 0);
				break;
			case 99:
				//DRT_ACTOR_PLAY_EFT("I_fire_wing003", "BOT", 0);
				break;
			case 108:
				//DRT_ACTOR_PLAY_EFT("F_ground059_fire2", "BOT", 0);
				break;
			case 122:
				//DRT_ACTOR_PLAY_EFT("F_smoke064_red1", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion049_fire", "MID", 0);
				//DRT_CLEAR_EFFECT();
				break;
			case 123:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "MID", 0);
				break;
			case 134:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG7");
				break;
			case 136:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG8");
				break;
			case 140:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG9");
				break;
			case 144:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG10");
				break;
			case 167:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG11");
				break;
			case 169:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "MID", 0);
				break;
			case 174:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 186:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG12");
				break;
			case 194:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG13");
				break;
			case 198:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG14");
				break;
			case 202:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG15");
				break;
			case 205:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 0);
				break;
			case 206:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 0);
				break;
			case 207:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 1);
				break;
			case 208:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 0);
				break;
			case 214:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG16");
				break;
			case 226:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_fire_loop", "BOT");
				break;
			case 237:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ04_TRACK_DLG17");
				break;
			case 238:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_fire_loop", "MID");
				break;
			case 246:
				//DRT_ACTOR_PLAY_EFT("F_smoke014_firesteam_dead", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out032_red", "BOT", 0);
				break;
			case 247:
				//DRT_ACTOR_PLAY_EFT("F_burstup030_fire_1", "BOT", 0);
				break;
			case 249:
				//DRT_ACTOR_PLAY_EFT("F_spread_in032_fire3", "BOT", 0);
				break;
			case 257:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
