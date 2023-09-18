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

[TrackScript("EP13_2_DPRISON1_MQ_3_TRACK_1")]
public class EP132DPRISON1MQ3TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_3_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(1254.59,198.63,-253.93);
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
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON1_MQ_3_DLG1", 3);
				break;
			case 20:
				//TRACK_MON_LOOKAT();
				break;
			case 37:
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 38:
				character.AddonMessage("NOTICE_Dm_scroll", "Stop the monsters and chase the Beholder!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
