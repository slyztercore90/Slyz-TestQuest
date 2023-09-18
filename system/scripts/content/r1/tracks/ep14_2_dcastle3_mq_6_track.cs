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

[TrackScript("EP14_2_DCASTLE3_MQ_6_TRACK")]
public class EP142DCASTLE3MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_6_TRACK");
		//SetMap("ep14_2_d_castle_3");
		//CenterPos(-11.77,105.10,1876.91);
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
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_violet", "MID");
				break;
			case 45:
				//DRT_CLEAR_EFFECT();
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_violet", "MID");
				break;
			case 53:
				//DRT_CLEAR_EFFECT();
				break;
			case 99:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
