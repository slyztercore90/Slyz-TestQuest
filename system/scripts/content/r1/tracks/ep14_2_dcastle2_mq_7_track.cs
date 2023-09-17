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

[TrackScript("EP14_2_DCASTLE2_MQ_7_TRACK")]
public class EP142DCASTLE2MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_7_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-1349.71,68.03,654.07);
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
			case 12:
				character.AddonMessage("NOTICE_Dm_!", "Magic Control Device can not be activated due to lack of mana!", 2);
				break;
			case 19:
				break;
			case 32:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 34:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE2_MQ_7_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
