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

[TrackScript("EP14_1_RAID_PREVIEW_TRACK")]
public class EP141RAIDPREVIEWTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_RAID_PREVIEW_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(-1649.79,180.75,-70.58);
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
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 4:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 5:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 6:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 7:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 18:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 19:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 20:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 35:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_9_TRACK_DLG1");
				break;
			case 41:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_9_TRACK_DLG2");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
