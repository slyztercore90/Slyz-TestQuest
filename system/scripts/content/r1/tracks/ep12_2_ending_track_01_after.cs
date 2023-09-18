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

[TrackScript("EP12_2_ENDING_TRACK_01_AFTER")]
public class EP122ENDINGTRACK01AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_01_AFTER");
		//SetMap("d_dcapital_108");
		//CenterPos(473.77,23.86,2023.83);
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
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				//DRT_ACTOR_PLAY_EFT("F_rize006_red", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_05");
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_smoke185_spread_out_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_firetower_teleport", "BOT");
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
