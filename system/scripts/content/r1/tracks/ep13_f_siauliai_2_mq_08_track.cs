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

[TrackScript("EP13_F_SIAULIAI_2_MQ_08_TRACK")]
public class EP13FSIAULIAI2MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_2_MQ_08_TRACK");
		//SetMap("ep13_f_siauliai_2");
		//CenterPos(919.34,256.39,1212.89);
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
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("None", "BOT", 0);
				break;
			case 21:
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_ground092_dark", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_explosion093_dark4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_explosion093_dark4", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_explosion093_dark4", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_smoke007_dark", "MID", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_explosion007_white", "MID", 0);
				break;
			case 50:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop", "BOT");
				break;
			case 51:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_08_DLG_T1");
				break;
			case 52:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_08_DLG_T2");
				break;
			case 54:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_2_MQ_08_T_BALLOON", 3);
				break;
			case 55:
				//DRT_CLEAR_EFFECT();
				//DRT_RUN_FUNCTION("EP13_MQ_HEADONICON_01");
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_light048_yellow2", "MID", 0);
				break;
			case 68:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_08_DLG_T3");
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_dark", "BOT", 0);
				break;
			case 80:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_08_DLG_T4");
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in001_violet", "BOT", 0);
				break;
			case 99:
				//DRT_ACTOR_PLAY_EFT("F_spread_out061_darkred", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation004_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup029_smoke_violet2", "BOT", 0);
				break;
			case 112:
				//DRT_ACTOR_PLAY_EFT("F_spread_out026_violet", "BOT", 0);
				break;
			case 113:
				//DRT_ACTOR_PLAY_EFT("F_spread_out026_violet", "BOT", 0);
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("F_spread_out026_violet", "BOT", 0);
				break;
			case 115:
				//DRT_ACTOR_PLAY_EFT("F_spread_out026_violet", "BOT", 0);
				break;
			case 124:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "Go to Paupys Crossing after defeating Darbas Smasher", 3);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
