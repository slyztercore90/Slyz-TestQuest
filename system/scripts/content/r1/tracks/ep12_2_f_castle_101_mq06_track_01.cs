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

[TrackScript("EP12_2_F_CASTLE_101_MQ06_TRACK_01")]
public class EP122FCASTLE101MQ06TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ06_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(-152.70,52.93,-680.61);
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
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_violet", "TOP", 0);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_firetower_teleport", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_2");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 75:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_3");
				break;
			case 79:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
