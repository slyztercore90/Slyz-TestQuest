//--- Melia Script -----------------------------------------------------------
// QUEST_20230130_014581
//--- Description -----------------------------------------------------------
// Quest to Rescue Rose.
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

[QuestScript(91186)]
public class Quest91186Script : QuestScript
{
	protected override void Load()
	{
		SetId(91186);
		SetName("QUEST_20230130_014581");
		SetDescription("Rescue Rose");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY3_5_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_4"));
		AddPrerequisite(new LevelPrerequisite(487));

		AddObjective("kill0", "Kill 1 QUEST_20230130_014581", new KillObjective(59776, 1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_EP15_1_F_ABBEY3_5_1_TRACK;
		var dialog = new Dialog(character, null);
		dialog.HideNPC("EP15_1_FABBEY3_BLOCK");
	}
}

