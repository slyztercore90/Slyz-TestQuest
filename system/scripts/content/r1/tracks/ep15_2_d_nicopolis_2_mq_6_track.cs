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

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_6_TRACK")]
public class EP152DNICOPOLIS2MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_6_TRACK");
		//SetMap("None");
		//CenterPos(52.47,0.50,856.17);
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
			case 5:
				break;
			case 9:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG1");
				break;
			case 13:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG2");
				break;
			case 17:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG3");
				break;
			case 35:
				break;
			case 38:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG4");
				break;
			case 41:
				Send.ZC_NORMAL.Notice(character, "EP15_2_D_NICOPOLIS_2_MQ_6_DLG5", 3);
				break;
			case 62:
				break;
			case 80:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
