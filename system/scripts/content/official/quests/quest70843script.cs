//--- Melia Script -----------------------------------------------------------
// Going through enemy plans
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70843)]
public class Quest70843Script : QuestScript
{
	protected override void Load()
	{
		SetId(70843);
		SetName("Going through enemy plans");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ03"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddObjective("collect0", "Collect 10 Demon Orders(s)", new CollectItemObjective("WHITETREES23_3_SQ03_ITEM", 10));
		AddDrop("WHITETREES23_3_SQ03_ITEM", 9f, "kucarry_zabbi");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES233_SQ_04_start", "WHITETREES23_3_SQ04", "Say that you will gladly help", "Say that you doubt more information will help"))
			{
				case 1:
					await dialog.Msg("WHITETREES233_SQ_04_agree");
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
			if (character.Inventory.HasItem("WHITETREES23_3_SQ03_ITEM", 10))
			{
				character.Inventory.RemoveItem("WHITETREES23_3_SQ03_ITEM", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("WHITETREES233_SQ_04_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

