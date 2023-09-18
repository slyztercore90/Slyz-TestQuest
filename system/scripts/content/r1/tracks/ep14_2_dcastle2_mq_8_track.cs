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

[TrackScript("EP14_2_DCASTLE2_MQ_8_TRACK")]
public class EP142DCASTLE2MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_8_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-1349.42,68.03,648.70);
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
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "TOP");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_Clear", "Magic Control Device is activating!", 2);
				break;
			case 24:
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
