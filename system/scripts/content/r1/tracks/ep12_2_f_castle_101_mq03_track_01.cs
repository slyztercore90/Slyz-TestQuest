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

[TrackScript("EP12_2_F_CASTLE_101_MQ03_TRACK_01")]
public class EP122FCASTLE101MQ03TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ03_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(923.07,124.55,418.92);
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
			case 4:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_02");
				break;
			case 5:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ03_DLG_05", 2);
				break;
			case 20:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_03");
				break;
			case 21:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_04");
				break;
			case 34:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_06");
				break;
			case 38:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_07");
				break;
			case 39:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_08");
				break;
			case 40:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_09");
				break;
			case 42:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_10");
				break;
			case 43:
				//DRT_FUNC_ACT("SCR_EP12_2_F_CASTLE_101_MQ03_TRACKINSELDLG");
				break;
			case 44:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_11");
				break;
			case 47:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_01");
				break;
			case 59:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_12");
				break;
			case 67:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_13");
				break;
			case 73:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
