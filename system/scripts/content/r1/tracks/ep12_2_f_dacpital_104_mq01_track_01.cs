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

[TrackScript("EP12_2_F_DACPITAL_104_MQ01_TRACK_01")]
public class EP122FDACPITAL104MQ01TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_DACPITAL_104_MQ01_TRACK_01");
		//SetMap("f_dcapital_104");
		//CenterPos(633.36,160.52,1958.70);
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
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_SET");
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_DACPITAL_104_MQ01_DLG_03", 3);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_light106_drop", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_light010", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_CLEAR");
				break;
			case 39:
				await track.Dialog.Msg("EP12_2_F_DACPITAL_104_MQ01_DLG_04");
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
