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

[TrackScript("JOB_CLERIC5_1_TRACK")]
public class JOBCLERIC51TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_CLERIC5_1_TRACK");
		//SetMap("None");
		//CenterPos(968.80,150.12,-480.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57163, "", "None", 934.9523, 150.1205, -389.01, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
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
