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

[TrackScript("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_1")]
public class EP132DPRISON3MQ2345TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(701.74,10.10,-1001.86);
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
			case 1:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG1");
				break;
			case 2:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG2");
				break;
			case 3:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG3");
				break;
			case 4:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG4");
				break;
			case 5:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG5");
				break;
			case 6:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG6");
				break;
			case 13:
				break;
			case 20:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG8");
				break;
			case 21:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG7");
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG9", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
