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

[TrackScript("EP12_PRELUDE_08_TRACK")]
public class EP12PRELUDE08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_08_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-549.80,0.22,10.74);
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
			case 26:
				break;
			case 34:
				break;
			case 73:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere008_boss_barrier_mash_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere008_boss_barrier_mash_loop", "MID");
				break;
			case 91:
				//DRT_PLAY_MGAME("EP12_PRELUDE_08_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
