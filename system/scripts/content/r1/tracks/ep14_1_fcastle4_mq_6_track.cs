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

[TrackScript("EP14_1_FCASTLE4_MQ_6_TRACK")]
public class EP141FCASTLE4MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_6_TRACK");
		//SetMap("ep14_1_f_castle_4");
		//CenterPos(259.02,24.50,561.72);
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
			case 27:
				//TRACK_MON_LOOKAT();
				break;
			case 31:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_1");
				break;
			case 32:
				//TRACK_MON_LOOKAT();
				break;
			case 33:
				//DRT_FUNC_ACT("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_MON_BUFF");
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "BOT", 0);
				break;
			case 40:
				//DRT_JUMP_TO_POS(0.2, 200);
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "MID", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "TOP", 0);
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("I_smoke035_dark", "MID", 0);
				break;
			case 67:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_6_TRACK_DLG1");
				break;
			case 71:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_3");
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "BOT", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "TOP", 0);
				break;
			case 76:
				//DRT_FUNC_ACT("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_2");
				break;
			case 94:
				//TRACK_BASICLAYER_MOVE();
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_CLEARDAYLIGHY");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
