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

[TrackScript("KATYN_10_MQ_01_TRACK")]
public class KATYN10MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_10_MQ_01_TRACK");
		//SetMap("f_katyn_10");
		//CenterPos(2915.39,73.81,-1243.67);
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
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_ice", "None", "None", "None", "SLOW", 60, 1, 0, 5, 10, 0);
				break;
			case 9:
				//TRACK_MON_LOOKAT();
				break;
			case 10:
				character.AddonMessage("NOTICE_Dm_!", "It seems that the monsters are using the{nl}Owl Sculptures to send light beads to somewhere else.", 5);
				break;
			case 14:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
