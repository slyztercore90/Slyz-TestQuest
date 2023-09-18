//--- Melia Script -----------------------------------------------------------
// Helping the Boy (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Boy.
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

[QuestScript(41833)]
public class Quest41833Script : QuestScript
{
	protected override void Load()
	{
		SetId(41833);
		SetName("Helping the Boy (1)");
		SetDescription("Talk to the Laker Boy");

		AddPrerequisite(new LevelPrerequisite(395));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_1_DLG1", "F_3CMLAKE_27_3_SQ_1", "Help", "Sorry, I'll have to refuse."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_3_SQ_1_DLG2");
				dialog.UnHideNPC("F_3CMLAKE_27_3_SQ_1_HNPC");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("F_3CMLAKE_27_3_SQ_2_ITEM", 9))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_27_3_SQ_2_ITEM", 9);
			await dialog.Msg("F_3CMLAKE_27_3_SQ_1_DLG4");
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("F_3CMLAKE_27_3_SQ_1_HNPC");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_3_SQ_2");
	}
}

