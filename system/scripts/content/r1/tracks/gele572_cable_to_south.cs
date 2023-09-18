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

[TrackScript("GELE572_CABLE_TO_SOUTH")]
public class GELE572CABLETOSOUTH : TrackScript
{
	protected override void Load()
	{
		SetId("GELE572_CABLE_TO_SOUTH");
		//SetMap("f_gele_57_2");
		//CenterPos(-27.38,375.39,979.15);
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
				//AttachToBGModelNode("f_gele57_2_cable_left_move", "cable_randing01", 120, 0.7);
				break;
			case 9:
				//DRT_BGMODEL_ANIM("f_gele57_2_cable_left_move", "f_gele57_2_cable_left_move.xsm", 0);
				break;
			case 34:
				//DRT_BGMODEL_ANIM("f_gele57_2_cable_left_move", "f_gele57_2_cable_left_std.xsm", 0);
				//AttachToBGModelNode("None", "Dummy003", 120, 0.7);
				//DRT_JUMP_TO_POS(1, 200);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
