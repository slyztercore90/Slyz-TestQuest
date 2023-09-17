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

[TrackScript("EP13_2_DPRISON3_MQ_3_TRACK_1")]
public class EP132DPRISON3MQ3TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_3_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(681.17,10.10,590.80);
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
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke015_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion052_green", "BOT", 0);
				break;
			case 19:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_3_TRACK_DLG1");
				break;
			case 26:
				break;
			case 27:
				break;
			case 28:
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_3_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
