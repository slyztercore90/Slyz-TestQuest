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

[TrackScript("EP14_1_FCASTLE5_MQ_2_TRACK")]
public class EP141FCASTLE5MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_2_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(1457.23,135.00,45.40);
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
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_ground071_smoke3", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_ground071_smoke3", "BOT", 0);
				break;
			case 40:
				break;
			case 42:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 49:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 56:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 124:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_2_TRACK_DLG1");
				break;
			case 129:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				break;
			case 133:
				character.AddonMessage("NOTICE_Dm_scroll", "Attack the left front.", 3);
				break;
			case 135:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
