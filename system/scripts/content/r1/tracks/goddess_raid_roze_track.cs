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

[TrackScript("Goddess_Raid_Roze_TRACK")]
public class GoddessRaidRozeTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("Goddess_Raid_Roze_TRACK");
		//SetMap("raid_Rosethemisterable");
		//CenterPos(-128.83,0.50,82.88);
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
				//DRT_CAM_ZOOM_NEW(120, 0, 0);
				break;
			case 6:
				//DRT_CAM_ZOOM_NEW(80, 20, 1);
				break;
			case 19:
				//DRT_CAM_ZOOM_NEW(200, 0, 0);
				break;
			case 20:
				//DRT_CAM_ZOOM_NEW(300, 20, 1);
				break;
			case 45:
				//DRT_CAM_ZOOM_NEW(0, 0, 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
