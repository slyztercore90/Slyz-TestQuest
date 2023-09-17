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

[TrackScript("F_3CMLAKE261_SQ01_TRACK")]
public class F3CMLAKE261SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ01_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(1274.34,-121.90,791.00);
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
			case 13:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG05");
				break;
			case 32:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG06");
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 36:
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 67:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG07");
				break;
			case 69:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
