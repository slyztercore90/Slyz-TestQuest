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

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_5_TRACK2")]
public class EP152DNICOPOLIS2MQ5TRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_5_TRACK2");
		//SetMap("None");
		//CenterPos(-31.01,0.50,741.71);
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
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern029_dark_violet_loop", "BOT");
				break;
			case 10:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_5_DLG3");
				break;
			case 19:
				//DRT_PLAY_MGAME("EP15_2_D_NICOPOLIS_2_MQ_5_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
