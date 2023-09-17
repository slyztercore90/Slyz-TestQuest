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

[TrackScript("EP12_PRELUDE_04_AFTER_TRACK")]
public class EP12PRELUDE04AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_04_AFTER_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-1188.45,164.35,992.66);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 43:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 70:
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 87:
				character.AddonMessage("NOTICE_Dm_Clear", "[Creeping Darkness(4)]{nl}Completed!", 5);
				break;
			case 89:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
