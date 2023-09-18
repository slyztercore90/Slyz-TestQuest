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

[TrackScript("EP13_F_SIAULIAI_3_MQ_05_TRACK")]
public class EP13FSIAULIAI3MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_MQ_05_TRACK");
		//SetMap("ep13_f_siauliai_3");
		//CenterPos(596.93,209.72,704.00);
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
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_explosion037_violet", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_violet", "MID", 0);
				break;
			case 35:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_05_DLG_T1");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_3_MQ_05_DLG_T2", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
