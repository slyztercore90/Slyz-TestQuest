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

[TrackScript("EP13_F_SIAULIAI_1_SQ_03_TRACK")]
public class EP13FSIAULIAI1SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_SQ_03_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(987.81,25.35,114.30);
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
				break;
			case 6:
				break;
			case 7:
				break;
			case 9:
				break;
			case 10:
				break;
			case 11:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 14:
				break;
			case 19:
				await track.Dialog.Msg("EP13_F_SIAULIAI_1_SQ_03_T_1");
				break;
			case 22:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 25:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 28:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 31:
				await track.Dialog.Msg("EP13_F_SIAULIAI_1_SQ_03_T_2");
				break;
			case 32:
				character.AddSessionObject(PropertyName.EP13_F_SIAULIAI_1_SQ_03, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
