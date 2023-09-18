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

[TrackScript("EP14_2_DCASTLE2_MQ_9_TRACK")]
public class EP142DCASTLE2MQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_9_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-1449.08,-2.33,-753.08);
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
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "TOP");
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_!", "The sound of something crashing could be heard from the Central Square{nl}as the last device was activated.", 2);
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				//DRT_CLEAR_EFFECT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
