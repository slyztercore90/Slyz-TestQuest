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

[TrackScript("EP15_2_D_NICOPOLIS_1_MQ_6_TRACK2")]
public class EP152DNICOPOLIS1MQ6TRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_1_MQ_6_TRACK2");
		//SetMap("None");
		//CenterPos(959.21,74.54,754.21);
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
			case 10:
				break;
			case 19:
				break;
			case 23:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_6_DLG1");
				break;
			case 30:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
