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

[TrackScript("EP12_2_ENDING_TRACK_01")]
public class EP122ENDINGTRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_01");
		//SetMap("d_dcapital_108");
		//CenterPos(470.84,23.86,1836.35);
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
			case 23:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_1");
				break;
			case 24:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_2");
				break;
			case 25:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_3");
				break;
			case 27:
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "MID", 0);
				break;
			case 44:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_dark", "F_explosion026_rize_red2", "arrow_blow", "FAST", 200, 1, 0, 5, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_burstup006_dark", "BOT", 0);
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("I_thornbush001_mesh", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 59:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_11");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_dark", "TOP", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_explosion125_red", "BOT", 0);
				break;
			case 77:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_4");
				break;
			case 88:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ16_DLG_12", 10);
				break;
			case 89:
				//DRT_PLAY_MGAME("EP12_2_ENDING_MINI_01");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
