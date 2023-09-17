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

[TrackScript("EP15_1_F_ABBEY2_2_TRACK")]
public class EP151FABBEY22TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_2_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(854.70,156.78,-89.12);
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
			case 3:
				break;
			case 21:
				break;
			case 22:
				break;
			case 23:
				break;
			case 40:
				//DRT_FUNC_ACT("SCR_EP15_1_F_ABBEY2_MQ02_TRACK_DLG2");
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
