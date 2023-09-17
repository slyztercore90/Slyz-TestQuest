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

[TrackScript("EP15_1_F_ABBEY2_3_TRACK")]
public class EP151FABBEY23TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_3_TRACK");
		//SetMap("None");
		//CenterPos(808.16,156.78,-55.35);
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
			case 12:
				break;
			case 13:
				break;
			case 15:
				break;
			case 18:
				break;
			case 42:
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY2_3_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
