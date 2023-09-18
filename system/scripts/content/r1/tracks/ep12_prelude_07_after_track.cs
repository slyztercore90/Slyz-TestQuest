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

[TrackScript("EP12_PRELUDE_07_AFTER_TRACK")]
public class EP12PRELUDE07AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_07_AFTER_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-44.12,68.06,456.47);
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
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_blue", "MID", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_blue", "MID", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_spread_out032", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out032_3", "BOT", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 118:
				character.AddonMessage("NOTICE_Dm_Clear", "[Creeping Darkness(7)]{nl}Completed!", 10);
				break;
			case 119:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
