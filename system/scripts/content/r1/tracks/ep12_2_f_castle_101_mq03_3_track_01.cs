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

[TrackScript("EP12_2_F_CASTLE_101_MQ03_3_TRACK_01")]
public class EP122FCASTLE101MQ033TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ03_3_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(335.29,52.93,-1015.08);
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
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_03");
				break;
			case 31:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_04");
				break;
			case 32:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 37:
				//DRT_FUNC_ACT("EP12_2_F_CASTLE_101_MQ_HEADONICON_01");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				break;
			case 47:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_05");
				break;
			case 48:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_06");
				break;
			case 49:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_07");
				break;
			case 50:
				//DRT_FUNC_ACT("SCR_EP12_2_F_CASTLE_101_MQ03_3_TRACKINSELDLG");
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
