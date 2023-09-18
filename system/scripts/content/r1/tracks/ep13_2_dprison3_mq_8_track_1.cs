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

[TrackScript("EP13_2_DPRISON3_MQ_8_TRACK_1")]
public class EP132DPRISON3MQ8TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_8_TRACK_1");
		//SetMap("None");
		//CenterPos(-170.58,15.22,72.51);
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
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup015_blue", "BOT", 0);
				break;
			case 10:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG1");
				break;
			case 11:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG2");
				break;
			case 25:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG3");
				break;
			case 26:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION3_MQ8_TRACK_HEADICON_1");
				break;
			case 33:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG4");
				break;
			case 34:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG5");
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow009_yellow", "arrow_cast", "F_only_quest_light115_explosion_blue", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 38:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 270, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 400, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 350, 1, 200, 0, 0, 0);
				break;
			case 41:
				break;
			case 42:
				break;
			case 43:
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground083_smoke_dark", "BOT", 0);
				break;
			case 56:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground093_dark", "BOT", 0);
				break;
			case 125:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON3_MQ_8_TRACK_DLG6", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
