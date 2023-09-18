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

[TrackScript("WHITETREES23_3_SQ09_TRACK")]
public class WHITETREES233SQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_3_SQ09_TRACK");
		//SetMap("f_whitetrees_23_3");
		//CenterPos(-574.02,160.13,572.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-444.1256f, 161.4477f, 366.7325f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47103, "", "f_whitetrees_23_3", -479.37, 161.8, 395.19, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155145, "", "f_whitetrees_23_3", -440.72, 161.82, 395, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47330, "", "f_whitetrees_23_3", -705.72, 161.71, 415.37, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155149, "", "f_whitetrees_23_3", -705.72, 161.71, 415.37, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_23_3", -545.5395, 161.2731, 351.9143, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_light063_spark_red", "MID", 1);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_light069_red2", "MID", 0);
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light009_yellow2", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "TOP");
				break;
			case 24:
				break;
			case 39:
				await track.Dialog.Msg("WHITETREES233_SQ_09_succ");
				break;
			case 40:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
