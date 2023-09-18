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

[TrackScript("EP14_1_FCASTLE3_MQ_8_TRACK")]
public class EP141FCASTLE3MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE3_MQ_8_TRACK");
		//SetMap("ep14_1_f_castle_3");
		//CenterPos(253.66,369.58,831.22);
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
			case 31:
				await track.Dialog.Msg("EP14_1_FCASTLE3_MQ_8_TRACK_DLG1");
				break;
			case 32:
				await track.Dialog.Msg("EP14_1_FCASTLE3_MQ_8_TRACK_DLG2");
				break;
			case 55:
				break;
			case 57:
				break;
			case 59:
				break;
			case 61:
				break;
			case 63:
				break;
			case 65:
				break;
			case 67:
				break;
			case 69:
				break;
			case 71:
				break;
			case 73:
				break;
			case 99:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE3_MQ_8_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
