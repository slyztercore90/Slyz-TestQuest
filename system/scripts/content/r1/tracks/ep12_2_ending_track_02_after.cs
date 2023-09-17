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

[TrackScript("EP12_2_ENDING_TRACK_02_AFTER")]
public class EP122ENDINGTRACK02AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_02_AFTER");
		//SetMap("d_dcapital_108");
		//CenterPos(470.80,23.86,2242.14);
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
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_burstup029_smoke_dark2", "BOT", 0);
				break;
			case 9:
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "TOP", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "TOP", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize006_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_holy_loop", "BOT");
				break;
			case 52:
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash029_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_explosion004_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_light013_spark_yellow", "MID", 0);
				break;
			case 61:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 62:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 63:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 80:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 83:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 84:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 85:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 87:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 88:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 89:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 95:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 96:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 102:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow2", "BOT");
				break;
			case 116:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_8");
				break;
			case 117:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_9");
				break;
			case 134:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ17_DLG_6", 10);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
