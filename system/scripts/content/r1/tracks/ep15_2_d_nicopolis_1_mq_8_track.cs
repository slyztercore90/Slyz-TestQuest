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

[TrackScript("EP15_2_D_NICOPOLIS_1_MQ_8_TRACK")]
public class EP152DNICOPOLIS1MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_1_MQ_8_TRACK");
		//SetMap("ep15_2_d_nicopolis_1");
		//CenterPos(-417.17,74.54,779.59);
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
			case 1:
				break;
			case 10:
				break;
			case 13:
				break;
			case 19:
				break;
			case 20:
				break;
			case 35:
				//DRT_PLAY_MGAME("EP15_2_D_NICOPOLIS_1_MQ_8_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
