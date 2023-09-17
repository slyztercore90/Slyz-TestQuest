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

[TrackScript("EP12_2_F_CASTLE_101_MQ03_2_TRACK_01")]
public class EP122FCASTLE101MQ032TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ03_2_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(1013.59,52.93,-671.48);
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
			case 25:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_2_DLG_03");
				break;
			case 30:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_01");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				break;
			case 44:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_2_DLG_04");
				break;
			case 45:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_2_DLG_05");
				break;
			case 46:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_2_DLG_06");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
