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

[TrackScript("EP15_1_F_ABBEY3_1_TRACK")]
public class EP151FABBEY31TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY3_1_TRACK");
		//SetMap("None");
		//CenterPos(30.61,186.43,-1314.84);
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
			case 12:
				break;
			case 17:
				break;
			case 31:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY3_1_MINI");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
