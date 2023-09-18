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

[TrackScript("JOB_PRIEST2_1_TRACK")]
public class JOBPRIEST21TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_PRIEST2_1_TRACK");
		//SetMap("f_siauliai_out");
		//CenterPos(54.90,88.36,-952.59);
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
				//DRT_ACTOR_PLAY_EFT("F_lineup014_yellow", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("buff_icon_dark", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 1);
				break;
			case 23:
				//CREATE_BATTLE_BOX_INLAYER(100);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
