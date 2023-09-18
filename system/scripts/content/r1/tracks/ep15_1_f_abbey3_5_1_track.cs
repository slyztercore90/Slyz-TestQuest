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

[TrackScript("EP15_1_F_ABBEY3_5_1_TRACK")]
public class EP151FABBEY351TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY3_5_1_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(754.12,5.92,-599.06);
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
			case 20:
				//DRT_FUNC_ACT("SCR_EP15_1_F_ABBEY3_MQ05_TRACK_DLG1");
				break;
			case 22:
				await track.Dialog.Msg("EP15_1_F_ABBEY_3_5_DLG2");
				break;
			case 23:
				break;
			case 40:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG3");
				break;
			case 43:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
