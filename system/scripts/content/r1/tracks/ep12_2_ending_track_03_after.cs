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

[TrackScript("EP12_2_ENDING_TRACK_03_AFTER")]
public class EP122ENDINGTRACK03AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_03_AFTER");
		//SetMap("d_dcapital_108");
		//CenterPos(474.42,23.86,2482.05);
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
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ18_DLG_27", 3);
				break;
			case 25:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_28");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 54:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_smoke181_white", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light066_yellow_loop2", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 88:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke_giltineraid_02_downsmoke_loop", "BOT");
				break;
			case 101:
				//DRT_ACTOR_PLAY_EFT("F_smoke_giltineraid_02_downsmoke", "BOT", 0);
				break;
			case 129:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("SCR_EP12_2_STORY_AFTER");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
