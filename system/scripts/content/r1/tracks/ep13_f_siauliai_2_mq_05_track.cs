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

[TrackScript("EP13_F_SIAULIAI_2_MQ_05_TRACK")]
public class EP13FSIAULIAI2MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_2_MQ_05_TRACK");
		//SetMap("None");
		//CenterPos(-1185.88,2.76,-1076.23);
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
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light106_drop", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light127", "MID", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 39:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_2_MQ_05_DLG_T1", 3);
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
