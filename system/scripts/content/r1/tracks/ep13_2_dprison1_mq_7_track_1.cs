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

[TrackScript("EP13_2_DPRISON1_MQ_7_TRACK_1")]
public class EP132DPRISON1MQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_7_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(736.80,207.00,1375.66);
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
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_blood009_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground133_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_out029_red", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup001_dark", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup006_dark", "BOT", 0);
				break;
			case 51:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON1_MQ_7_DLG1", 10);
				break;
			case 67:
				break;
			case 77:
				//TRACK_MON_LOOKAT();
				break;
			case 79:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_7_MGAME_1");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
