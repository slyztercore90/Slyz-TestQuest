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

[TrackScript("EP13_F_SIAULIAI_4_MQ03_TRACK")]
public class EP13FSIAULIAI4MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_4_MQ03_TRACK");
		//SetMap("ep13_f_siauliai_4");
		//CenterPos(170.86,79.94,-97.85);
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
			case 31:
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				break;
			case 73:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_5_MQ03_TRACK_ALERT", 2);
				break;
			case 92:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
