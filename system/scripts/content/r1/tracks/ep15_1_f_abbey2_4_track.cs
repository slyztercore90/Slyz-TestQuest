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

[TrackScript("EP15_1_F_ABBEY2_4_TRACK")]
public class EP151FABBEY24TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_4_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(-1363.63,74.90,1547.44);
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
			case 59:
				break;
			case 60:
				break;
			case 62:
				break;
			case 63:
				break;
			case 67:
				break;
			case 89:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY2_4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
