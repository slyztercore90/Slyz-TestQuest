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

[TrackScript("EP13_F_SIAULIAI_3_HQ_01_TRACK")]
public class EP13FSIAULIAI3HQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_HQ_01_TRACK");
		//SetMap("None");
		//CenterPos(1072.90,318.81,1495.58);
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
			case 21:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_HQ_01_TRACK_1");
				break;
			case 48:
				character.AddSessionObject(PropertyName.EP13_F_SIAULIAI_3_HQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
