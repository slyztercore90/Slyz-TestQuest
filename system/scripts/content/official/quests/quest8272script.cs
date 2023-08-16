//--- Melia Script -----------------------------------------------------------
// Interruption of the monster blocking the road
//--- Description -----------------------------------------------------------
// Quest to Interruption of the monster blocking the road.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(8272)]
public class Quest8272Script : QuestScript
{
	protected override void Load()
	{
		SetId(8272);
		SetName("Interruption of the monster blocking the road");
		SetDescription("Interruption of the monster blocking the road");
		SetTrack("SProgress", "ESuccess", "KATYN14_SUB_06_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Red Fisherman(s)", new KillObjective(400344, 6));

		AddDialogHook("KATYN14_SUB_06", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("Notice/!/길을 막고있는 몬스터를 처치하세요!#8", "KATYN14_SUB_06", "Accept", "Cancel"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

