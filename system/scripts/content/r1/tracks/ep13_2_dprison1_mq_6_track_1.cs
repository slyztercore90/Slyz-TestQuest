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

[TrackScript("EP13_2_DPRISON1_MQ_6_TRACK_1")]
public class EP132DPRISON1MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(996.09,230.78,1114.26);
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
			case 42:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_6_DLG1");
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke191_blue", "BOT", 0);
				break;
			case 45:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_6_DLG2");
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "MID", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke185_spread_out_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground083_smoke_dark", "BOT", 0);
				break;
			case 66:
				break;
			case 76:
				//TRACK_MON_LOOKAT();
				break;
			case 79:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_6_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
