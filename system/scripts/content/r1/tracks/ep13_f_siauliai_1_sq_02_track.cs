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

[TrackScript("EP13_F_SIAULIAI_1_SQ_02_TRACK")]
public class EP13FSIAULIAI1SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_SQ_02_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(1113.20,25.35,121.65);
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
			case 15:
				break;
			case 29:
				//DRT_PLAY_MGAME("EP13_F_SIAULIAI_1_SQ_02_MINI");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
