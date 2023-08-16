//--- Melia Script -----------------------------------------------------------
// Barha Forest's Antidote(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Adas.
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

[QuestScript(30206)]
public class Quest30206Script : QuestScript
{
	protected override void Load()
	{
		SetId(30206);
		SetName("Barha Forest's Antidote(2)");
		SetDescription("Talk to Researcher Adas");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddObjective("collect0", "Collect 4 Griba's Slimy Juice(s)", new CollectItemObjective("ORCHARD_34_3_SQ_ITEM2", 4));
		AddDrop("ORCHARD_34_3_SQ_ITEM2", 10f, "mushroom_ent_red");

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_34_3_SQ_2_select", "ORCHARD_34_3_SQ_2", "Say that you will gather Griba Juice", "Say that he is on his own now"))
			{
				case 1:
					await dialog.Msg("ORCHARD_34_3_SQ_2_agree");
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
			if (character.Inventory.HasItem("ORCHARD_34_3_SQ_ITEM2", 4))
			{
				character.Inventory.RemoveItem("ORCHARD_34_3_SQ_ITEM2", 4);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("ORCHARD_34_3_SQ_2_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

