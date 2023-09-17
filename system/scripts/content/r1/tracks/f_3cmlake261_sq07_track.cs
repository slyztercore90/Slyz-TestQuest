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

[TrackScript("F_3CMLAKE261_SQ07_TRACK")]
public class F3CMLAKE261SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ07_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(520.64,-89.70,-1194.81);
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
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_force036_green1", "MID");
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_Clear", "The blue light from the wings is heading towards something!", 3);
				break;
			case 27:
				character.AddonMessage("NOTICE_Dm_scroll", "The monsters that reacted to the wing's light prepare to fight you!", 3);
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder010_light_dark", "BOT");
				break;
			case 42:
				break;
			case 69:
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(-30);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
