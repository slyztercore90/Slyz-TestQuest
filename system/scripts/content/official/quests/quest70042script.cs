//--- Melia Script -----------------------------------------------------------
// Revenge Shall Be Mine
//--- Description -----------------------------------------------------------
// Quest to Talk to Gord Shaton.
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

[QuestScript(70042)]
public class Quest70042Script : QuestScript
{
	protected override void Load()
	{
		SetId(70042);
		SetName("Revenge Shall Be Mine");
		SetDescription("Talk to Gord Shaton");

		AddPrerequisite(new CompletedPrerequisite("FARM49_3_MQ02"));
		AddPrerequisite(new LevelPrerequisite(155));

		AddObjective("collect0", "Collect 13 Pink Tree Root Mole's Horn(s)", new CollectItemObjective("FARM49_3_MQ03_ITEM", 13));
		AddDrop("FARM49_3_MQ03_ITEM", 10f, "tree_root_mole_pink");

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_3_MQ_03_1", "FARM49_3_MQ03", "Persuade one more time", "Leave since he doesn't seem like he is in a good mood"))
			{
				case 1:
					await dialog.Msg("FARM49_3_MQ_03_2");
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
			if (character.Inventory.HasItem("FARM49_3_MQ03_ITEM", 13))
			{
				character.Inventory.RemoveItem("FARM49_3_MQ03_ITEM", 13);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FARM49_3_MQ_03_4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

