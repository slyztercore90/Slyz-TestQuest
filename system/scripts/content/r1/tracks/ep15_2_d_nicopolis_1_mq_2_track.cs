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

[TrackScript("EP15_2_D_NICOPOLIS_1_MQ_2_TRACK")]
public class EP152DNICOPOLIS1MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_1_MQ_2_TRACK");
		//SetMap("ep15_2_d_nicopolis_1");
		//CenterPos(-246.98,74.54,-1194.00);
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
			case 7:
				break;
			case 9:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG3");
				break;
			case 14:
				break;
			case 15:
				break;
			case 17:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG4");
				break;
			case 19:
				break;
			case 21:
				break;
			case 22:
				break;
			case 27:
				break;
			case 28:
				break;
			case 36:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG5");
				break;
			case 42:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
