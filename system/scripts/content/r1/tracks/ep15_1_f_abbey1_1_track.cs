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

[TrackScript("EP15_1_F_ABBEY1_1_TRACK")]
public class EP151FABBEY11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY1_1_TRACK");
		//SetMap("c_orsha");
		//CenterPos(146.59,176.08,293.55);
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
				break;
			case 9:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_katadikazo", "BOT");
				break;
			case 19:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_1_DLG3");
				break;
			case 30:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("EP15_1_ABBEY1_WARP");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
