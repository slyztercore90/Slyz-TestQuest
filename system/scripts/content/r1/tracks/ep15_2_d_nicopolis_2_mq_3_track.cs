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

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_3_TRACK")]
public class EP152DNICOPOLIS2MQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_3_TRACK");
		//SetMap("ep15_2_d_nicopolis_2");
		//CenterPos(-952.26,1.00,-611.17);
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
				break;
			case 14:
				break;
			case 15:
				break;
			case 21:
				break;
			case 22:
				break;
			case 23:
				break;
			case 25:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP15_2_D_NICOPOLIS_2_MQ_3_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
