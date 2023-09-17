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

[TrackScript("EP14_1_FCASTLE4_MQ_8_TRACK")]
public class EP141FCASTLE4MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_8_TRACK");
		//SetMap("None");
		//CenterPos(-604.97,58.68,2199.55);
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
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 7:
				//DRT_JUMP_TO_POS(0, 0);
				break;
			case 13:
				break;
			case 17:
				break;
			case 26:
				break;
			case 64:
				//DRT_PLAY_MGAME("EP14_1_FCASTLE4_MQ_8_MGAME");
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
