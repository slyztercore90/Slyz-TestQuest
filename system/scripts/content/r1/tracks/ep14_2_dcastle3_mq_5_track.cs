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

[TrackScript("EP14_2_DCASTLE3_MQ_5_TRACK")]
public class EP142DCASTLE3MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_5_TRACK");
		//SetMap("None");
		//CenterPos(-42.25,198.58,326.42);
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
			case 65:
				break;
			case 77:
				await track.Dialog.Msg("EP14_2_DCASTLE3_MQ_5_DLG1");
				break;
			case 82:
				break;
			case 99:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG3");
				break;
			case 114:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE3_MQ_5_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
