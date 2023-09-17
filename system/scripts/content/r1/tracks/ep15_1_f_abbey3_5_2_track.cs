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

[TrackScript("EP15_1_F_ABBEY3_5_2_TRACK")]
public class EP151FABBEY352TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY3_5_2_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(4.56,44.60,931.24);
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
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG4");
				break;
			case 11:
				break;
			case 20:
				break;
			case 34:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG5");
				break;
			case 45:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG6");
				break;
			case 49:
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_5_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
