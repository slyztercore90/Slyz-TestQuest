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

[TrackScript("EP15_1_F_ABBEY2_8_TRACK")]
public class EP151FABBEY28TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_8_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(-1341.36,74.90,1561.69);
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
				break;
			case 6:
				break;
			case 7:
				break;
			case 10:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG1");
				break;
			case 16:
				break;
			case 24:
				break;
			case 26:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG2");
				//DRT_SETPOS();
				break;
			case 42:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG3");
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
