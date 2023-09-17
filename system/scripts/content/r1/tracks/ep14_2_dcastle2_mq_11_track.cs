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

[TrackScript("EP14_2_DCASTLE2_MQ_11_TRACK")]
public class EP142DCASTLE2MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_11_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(12.10,68.03,624.49);
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
			case 20:
				break;
			case 24:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_11_DLG1");
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
