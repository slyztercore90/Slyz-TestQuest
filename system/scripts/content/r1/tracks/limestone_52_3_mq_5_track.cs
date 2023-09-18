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

[TrackScript("LIMESTONE_52_3_MQ_5_TRACK")]
public class LIMESTONE523MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_3_MQ_5_TRACK");
		//SetMap("d_limestonecave_52_3");
		//CenterPos(147.61,124.70,-1457.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(147.6131f, 124.7f, -1457.556f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154001, "", "d_limestonecave_52_3", 248.4947, 124.7, -1451.097, 12.04545);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154001, "", "d_limestonecave_52_3", 248.4947, 124.7, -1451.097, 13.86364);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_3", 171.4303, 124.7, -1444.272, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "", "d_limestonecave_52_3", 248.3256, 124.7, -1451.071, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_3", 144.0796, 124.7, -1484.531, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_3", 604.6644, 124.7, -1238.348, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_3", 690.4426, 124.7245, -1383.698, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 689.3825, 124.7245, -1385.37, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				await track.Dialog.Msg("LIMESTONE_52_3_MQ_5_TRACK_01");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 51:
				await track.Dialog.Msg("LIMESTONE_52_3_MQ_5_TRACK_02");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow", "BOT");
				break;
			case 61:
				await track.Dialog.Msg("LIMESTONE_52_3_MQ_5_TRACK_03");
				//DRT_ACTOR_ATTACH_EFFECT("I_chain004_mash_loop", "BOT");
				break;
			case 63:
				Send.ZC_NORMAL.Notice(character, "LIMESTONE_52_3_MQ_5_TRACK_04", 6);
				break;
			case 64:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
