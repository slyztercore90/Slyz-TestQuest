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

[TrackScript("EP13_F_SIAULIAI_4_MQ08_TRACK")]
public class EP13FSIAULIAI4MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_4_MQ08_TRACK");
		//SetMap("None");
		//CenterPos(-282.60,10.67,871.17);
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
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_devilglove_dead_mash", "BOT", 0);
				break;
			case 69:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
