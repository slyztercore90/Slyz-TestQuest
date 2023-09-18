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

[TrackScript("EP14_1_FCASTLE3_MQ_1_TRACK")]
public class EP141FCASTLE3MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE3_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_3");
		//CenterPos(338.99,0.75,-1667.33);
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
				//TRACK_MON_LOOKAT();
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 16:
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 18:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 19:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 25:
				break;
			case 50:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
