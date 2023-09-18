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

[TrackScript("EP15_1_F_ABBEY_3_2_TRACK")]
public class EP151FABBEY32TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_2_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(-4.75,113.52,-187.19);
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
			case 2:
				break;
			case 29:
				break;
			case 32:
				break;
			case 50:
				break;
			case 55:
				break;
			case 62:
				break;
			case 63:
				break;
			case 74:
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_2_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
