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

[TrackScript("EP15_2_D_NICOPOLIS_1_MQ_6_TRACK")]
public class EP152DNICOPOLIS1MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_1_MQ_6_TRACK");
		//SetMap("ep15_2_d_nicopolis_1");
		//CenterPos(777.51,74.54,785.25);
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
			case 11:
				break;
			case 12:
				break;
			case 14:
				break;
			case 16:
				break;
			case 22:
				//DRT_PLAY_MGAME("EP15_2_D_NICOPOLIS_1_MQ_6_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
