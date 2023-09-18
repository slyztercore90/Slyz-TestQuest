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

[TrackScript("EP12_FINALE_02_TRACK")]
public class EP12FINALE02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_FINALE_02_TRACK");
		//SetMap("f_dcapital_104");
		//CenterPos(330.50,-27.39,-105.15);
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
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 34:
				await track.Dialog.Msg("EP12_FINALE_02_DLG01");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_ground083_smoke_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 43:
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2", "BOT");
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowCondensation_dark", "BOT", 0);
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("F_archer_TripleArrow_hit_explosion", "BOT", 0);
				break;
			case 104:
				break;
			case 118:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_02_TRACK_DAYLIGHT_SET");
				break;
			case 127:
				await track.Dialog.Msg("EP12_FINALE_02_DLG02");
				break;
			case 131:
				await track.Dialog.Msg("EP12_FINALE_02_DLG03");
				break;
			case 134:
				await track.Dialog.Msg("EP12_FINALE_02_DLG04");
				break;
			case 136:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 137:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in025_red", "BOT", 0);
				break;
			case 147:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
