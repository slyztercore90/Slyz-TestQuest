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

[TrackScript("EP13_2_DPRISON3_MQ_1_TRACK_1")]
public class EP132DPRISON3MQ1TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_1_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(659.49,10.10,-1016.40);
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
			case 18:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG1");
				break;
			case 20:
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG2");
				break;
			case 42:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG3");
				break;
			case 59:
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_1_MGAME_1");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
