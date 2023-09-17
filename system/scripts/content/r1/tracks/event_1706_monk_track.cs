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

[TrackScript("EVENT_1706_MONK_TRACK")]
public class EVENT1706MONKTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EVENT_1706_MONK_TRACK");
		//SetMap("None");
		//CenterPos(-396.37,148.82,-96.93);
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
			case 7:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG1");
				break;
			case 13:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG2");
				break;
			case 15:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG3");
				break;
			case 17:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG4");
				break;
			case 19:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG5");
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
