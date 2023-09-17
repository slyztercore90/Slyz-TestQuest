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

[TrackScript("EP14_1_FCASTLE4_MQ_1_TRACK")]
public class EP141FCASTLE4MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_4");
		//CenterPos(1184.84,58.91,-1828.29);
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
			case 12:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008##0.2", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0, 0, 0, 0, 0);
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008##0.2", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0, 0, 0, 0, 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_spread_in053_dark", "MID", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 55:
				Send.ZC_NORMAL.Notice(character, "EP14_1_FCASTLE4_MQ_1_TRACK_DLG1", 1);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_explosion140_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke101_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				break;
			case 81:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_1_TRACK_DLG2");
				break;
			case 82:
				break;
			case 93:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_1_TRACK_DLG3");
				break;
			case 99:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE4_MQ_1_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
