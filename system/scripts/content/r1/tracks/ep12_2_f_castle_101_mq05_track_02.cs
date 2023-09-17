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

[TrackScript("EP12_2_F_CASTLE_101_MQ05_TRACK_02")]
public class EP122FCASTLE101MQ05TRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ05_TRACK_02");
		//SetMap("f_castle_101");
		//CenterPos(-1068.36,52.93,-873.15);
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
			case 10:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_2");
				break;
			case 11:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_3");
				break;
			case 14:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ05_DLG_7", 2);
				break;
			case 27:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_4");
				break;
			case 42:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				break;
			case 56:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_5");
				break;
			case 69:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_04");
				break;
			case 82:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_04");
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 106:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 110:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 122:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 126:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 130:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 135:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 139:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
