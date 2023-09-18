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

[TrackScript("EP12_2_F_CASTLE_101_MQ06_BEFORE_TRACK_01")]
public class EP122FCASTLE101MQ06BEFORETRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ06_BEFORE_TRACK_01");
		//SetMap("None");
		//CenterPos(-1150.60,52.93,-740.67);
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
			case 51:
				break;
			case 79:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_5");
				break;
			case 84:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ06_DLG_6", 3);
				break;
			case 107:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
