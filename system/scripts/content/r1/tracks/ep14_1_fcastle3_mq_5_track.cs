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

[TrackScript("EP14_1_FCASTLE3_MQ_5_TRACK")]
public class EP141FCASTLE3MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE3_MQ_5_TRACK");
		//SetMap("ep14_1_f_castle_3");
		//CenterPos(-1764.07,93.08,848.94);
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
			case 8:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0.5, 0, 0, 0, 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 11:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0.5, 0, 0, 0, 0);
				break;
			case 33:
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 65:
				await track.Dialog.Msg("EP14_1_FCASTLE3_MQ_5_TRACK_DLG1");
				break;
			case 74:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP14_1_FCASTLE3_MQ_5_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
