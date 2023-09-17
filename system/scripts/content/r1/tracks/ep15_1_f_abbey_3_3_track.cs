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

[TrackScript("EP15_1_F_ABBEY_3_3_TRACK")]
public class EP151FABBEY33TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_3_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(-759.33,5.92,-711.92);
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
			case 15:
				break;
			case 16:
				break;
			case 41:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_3_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
