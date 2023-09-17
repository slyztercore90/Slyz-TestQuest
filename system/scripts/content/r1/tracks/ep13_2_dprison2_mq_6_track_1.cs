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

[TrackScript("EP13_2_DPRISON2_MQ_6_TRACK_1")]
public class EP132DPRISON2MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON2_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_2");
		//CenterPos(-1029.36,546.48,-74.78);
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
				//DRT_SETPOS();
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 32:
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke058_blue", "BOT", 0);
				break;
			case 49:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG1");
				break;
			case 50:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ6_TRACK_HEADICON_1");
				break;
			case 60:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG2");
				break;
			case 61:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG3");
				break;
			case 62:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG4");
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup015_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "None", "arrow_blow", "SLOW", 20, 0, 0, 0, 0, 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_light076_spread_in_blue", "BOT", 0);
				break;
			case 78:
				break;
			case 80:
				break;
			case 81:
				break;
			case 83:
				break;
			case 86:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG5");
				break;
			case 89:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP13_2_DPRISON2_MQ_6_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
