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

[TrackScript("JOB_PSYCHOKINESIST4_1_TRACK")]
public class JOBPSYCHOKINESIST41TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_PSYCHOKINESIST4_1_TRACK");
		//SetMap("f_siauliai_out");
		//CenterPos(1529.61,196.04,416.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1538.984f, 170.5953f, 375.0425f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57167, "", "f_siauliai_out", 1454.218, 228.8698, 508.65, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 135;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
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
