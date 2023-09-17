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

[TrackScript("EP14_3LINE_TUTO_MQ_2_TRACK")]
public class EP143LINETUTOMQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_3LINE_TUTO_MQ_2_TRACK");
		//SetMap("c_klaipe_castle");
		//CenterPos(1857.06,-157.39,-498.23);
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
				break;
			case 24:
				break;
			case 27:
				break;
			case 30:
				break;
			case 32:
				await track.Dialog.Msg("EP14_3LINE_TUTO_MQ_2_TRACK_DLG_2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
