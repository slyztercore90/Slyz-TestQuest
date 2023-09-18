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

[TrackScript("EP12_FINALE_05_TRACK")]
public class EP12FINALE05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_FINALE_05_TRACK");
		//SetMap("f_dcapital_104");
		//CenterPos(416.05,129.03,1156.67);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground195_levitation_violet_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "BOT");
				break;
			case 9:
				await track.Dialog.Msg("EP12_FINALE_05_DLG02");
				break;
			case 13:
				await track.Dialog.Msg("EP12_FINALE_05_DLG03");
				break;
			case 17:
				await track.Dialog.Msg("EP12_FINALE_05_DLG04");
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_pc_CardBook_ground_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup022_dark", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 37:
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 63:
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 84:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("F_cleric_godsmash_shot_explosion", "BOT", 0);
				break;
			case 89:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 99:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 102:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				break;
			case 104:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 107:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				break;
			case 109:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 112:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_light013_spark_orange_2", "BOT", 0);
				break;
			case 115:
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "TOP");
				break;
			case 117:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				break;
			case 119:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 123:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic033_orange_line", "BOT", 0);
				break;
			case 124:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				break;
			case 125:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 126:
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "TOP");
				break;
			case 130:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 135:
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder007_light_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue3", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow2", "BOT", 0);
				break;
			case 140:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_02_TRACK_DAYLIGHT_SET");
				//DRT_ACTOR_PLAY_EFT("I_force071_dark", "MID", 0);
				break;
			case 165:
				await track.Dialog.Msg("EP12_FINALE_05_DLG05");
				break;
			case 170:
				await track.Dialog.Msg("EP12_FINALE_05_DLG06");
				break;
			case 175:
				await track.Dialog.Msg("EP12_FINALE_05_DLG07");
				break;
			case 184:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 185:
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in025_red", "BOT", 0);
				break;
			case 192:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
