//--- Melia Script -----------------------------------------------------------
// Last Mission (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Officer's Spirit.
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

[QuestScript(8229)]
public class Quest8229Script : QuestScript
{
	protected override void Load()
	{
		SetId(8229);
		SetName("Last Mission (4)");
		SetDescription("Talk to the Officer's Spirit");

		AddPrerequisite(new CompletedPrerequisite("KATYN71_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("collect0", "Collect 7 Ellom Leaves(s)", new CollectItemObjective("KATYN72_DUM_WO_03", 7));
		AddDrop("KATYN72_DUM_WO_03", 10f, "ellom");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_OFFICER_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN71_OFFICER_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN71_MQ_05_01", "KATYN71_MQ_05", "Collect Ellum Leaves", "I can only help so much"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("KATYN72_DUM_WO_03", 7))
			{
				character.Inventory.RemoveItem("KATYN72_DUM_WO_03", 7);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("KATYN71_MQ_05_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN71_MQ_06");
	}
}

