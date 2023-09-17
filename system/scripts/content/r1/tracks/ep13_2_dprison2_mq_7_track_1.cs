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

[TrackScript("EP13_2_DPRISON2_MQ_7_TRACK_1")]
public class EP132DPRISON2MQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON2_MQ_7_TRACK_1");
		//SetMap("ep13_2_d_prison_2");
		//CenterPos(-1077.00,546.48,-137.12);
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
			case 11:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_7_TRACK_DLG1");
				break;
			case 15:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ1_TRACK_HEADICON_1");
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_light115_explosion_blue2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 34:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion007_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion004_blue", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 81:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_7_TRACK_DLG2");
				break;
			case 84:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON2_MQ_7_TRACK_DLG3", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
