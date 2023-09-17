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

[TrackScript("EP13_F_SIAULIAI_1_MQ_06_TRACK")]
public class EP13FSIAULIAI1MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_MQ_06_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(-1634.05,65.41,-1339.84);
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
			case 15:
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_ground059_fire2", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_smoke168_darkpuple", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke178_puple", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 47:
				break;
			case 49:
				break;
			case 54:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_1_MQ_06_DLG_T1", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
