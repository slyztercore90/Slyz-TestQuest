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

[TrackScript("EP14_2_DCASTLE2_MQ_10_TRACK")]
public class EP142DCASTLE2MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_10_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-373.18,68.03,644.12);
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
			case 19:
				break;
			case 21:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG1");
				break;
			case 27:
				//DRT_SETPOS();
				break;
			case 29:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG2");
				break;
			case 35:
				break;
			case 47:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG3");
				break;
			case 74:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE2_MQ_10_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
