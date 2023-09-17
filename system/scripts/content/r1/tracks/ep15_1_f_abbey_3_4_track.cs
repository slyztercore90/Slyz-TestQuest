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

[TrackScript("EP15_1_F_ABBEY_3_4_TRACK")]
public class EP151FABBEY34TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_4_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(777.14,5.92,-601.93);
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
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("velcoffer_gimmick_prop_dead", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke014_firesteam_dead2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion007_pink", "TOP");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "TOP");
				break;
			case 14:
				break;
			case 15:
				break;
			case 41:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
