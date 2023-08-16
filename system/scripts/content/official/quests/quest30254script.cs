//--- Melia Script -----------------------------------------------------------
// Vincentas' Squan In Peril(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vincentas.
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

[QuestScript(30254)]
public class Quest30254Script : QuestScript
{
	protected override void Load()
	{
		SetId(30254);
		SetName("Vincentas' Squan In Peril(1)");
		SetDescription("Talk to Vincentas");

		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ10"), new CompletedPrerequisite("KATYN_45_3_SQ_11"), new CompletedPrerequisite("MASTER_RANGER1"), new CompletedPrerequisite("MASTER_RANGER2_2"));
		AddPrerequisite(new LevelPrerequisite(289));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("CASTLE_20_4_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_4_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE_20_4_SQ_1_select", "CASTLE_20_4_SQ_1", "As a Revelator, I cannot simply walk away.", "Goodbye."))
			{
				case 1:
					await dialog.Msg("CASTLE_20_4_SQ_1_agree");
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
			if (character.Inventory.HasItem("CASTLE_20_4_SQ_1_ITEM", 3))
			{
				character.Inventory.RemoveItem("CASTLE_20_4_SQ_1_ITEM", 3);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CASTLE_20_4_SQ_1_succ");
				dialog.HideNPC("CASTLE_20_4_OBJ_1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

