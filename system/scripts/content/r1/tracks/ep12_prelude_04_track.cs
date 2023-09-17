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

[TrackScript("EP12_PRELUDE_04_TRACK")]
public class EP12PRELUDE04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_04_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-1183.64,164.35,994.22);
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
			case 2:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 27:
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				break;
			case 36:
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_scroll", "The demons are drawn by the divine power and are trying to destroy Namott!{nl}Protect the Namott from the demons until their power is restored!", 7);
				break;
			case 45:
				//DRT_PLAY_MGAME("EP12_PRELUDE_04_MINI");
				break;
			case 46:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
