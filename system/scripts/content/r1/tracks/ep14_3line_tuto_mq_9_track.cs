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

[TrackScript("EP14_3LINE_TUTO_MQ_9_TRACK")]
public class EP143LINETUTOMQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_3LINE_TUTO_MQ_9_TRACK");
		//SetMap("c_klaipe_castle");
		//CenterPos(-275.96,-131.92,-280.93);
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
			case 36:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_1", 5);
				break;
			case 45:
				break;
			case 54:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_2", 3);
				break;
			case 69:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_3", 5);
				break;
			case 81:
				break;
			case 89:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_white", "BOT");
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_explosion006_orange1", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_orange", "BOT");
				break;
			case 106:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_4", 5);
				break;
			case 113:
				//DRT_CLEAR_EFFECT();
				//DRT_CLEAR_EFFECT();
				break;
			case 149:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_5", 3);
				break;
			case 160:
				Send.ZC_NORMAL.Notice(character, "EP14_3LINE_TUTO_MQ_9_TRACK_BALL_6", 3);
				break;
			case 174:
				character.AddSessionObject(PropertyName.EP14_3LINE_TUTO_MQ_9, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
