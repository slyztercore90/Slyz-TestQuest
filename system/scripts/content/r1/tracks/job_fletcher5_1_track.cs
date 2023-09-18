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

[TrackScript("JOB_FLETCHER5_1_TRACK")]
public class JOBFLETCHER51TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_FLETCHER5_1_TRACK");
		//SetMap("f_farm_47_2");
		//CenterPos(1358.80,-43.03,1033.00);
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
			case 13:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Yonazolem!", 3);
				break;
			case 14:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
