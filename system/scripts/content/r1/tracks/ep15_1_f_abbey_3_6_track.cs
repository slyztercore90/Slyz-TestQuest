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

[TrackScript("EP15_1_F_ABBEY_3_6_TRACK")]
public class EP151FABBEY36TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_6_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(-0.48,44.60,1159.21);
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
			case 12:
				break;
			case 13:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG1");
				break;
			case 16:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG2");
				break;
			case 22:
				break;
			case 37:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG3");
				break;
			case 43:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG4");
				break;
			case 48:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG5");
				break;
			case 52:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG6");
				break;
			case 55:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG7");
				break;
			case 59:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG8");
				break;
			case 66:
				break;
			case 73:
				//DRT_CLEAR_EFFECT();
				break;
			case 77:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop2", "BOT");
				break;
			case 79:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG9");
				break;
			case 81:
				break;
			case 94:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG10");
				break;
			case 112:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
