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

[TrackScript("EP15_1_F_ABBEY1_7_TRACK")]
public class EP151FABBEY17TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY1_7_TRACK");
		//SetMap("None");
		//CenterPos(-930.58,48.10,1358.37);
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
			case 4:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG2");
				break;
			case 7:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG3");
				break;
			case 10:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG4");
				break;
			case 17:
				break;
			case 25:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG5");
				break;
			case 30:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG6");
				break;
			case 34:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG7");
				break;
			case 35:
				break;
			case 45:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG8");
				break;
			case 60:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
