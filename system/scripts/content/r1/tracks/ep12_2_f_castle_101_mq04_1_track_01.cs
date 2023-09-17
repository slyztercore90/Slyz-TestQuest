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

[TrackScript("EP12_2_F_CASTLE_101_MQ04_1_TRACK_01")]
public class EP122FCASTLE101MQ041TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ04_1_TRACK_01");
		//SetMap("None");
		//CenterPos(-890.27,124.49,434.45);
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
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				break;
			case 25:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_1_DLG_3");
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
