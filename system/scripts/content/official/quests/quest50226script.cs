//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50226)]
public class Quest50226Script : QuestScript
{
	protected override void Load()
	{
		SetId(50226);
		SetName("Maven's Wishes(6)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ4"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN43_4_SQ5_START1", "BRACKEN43_4_SQ5", "Agree to gather Mittelly Herbs", "Say that you don't think it's your place to help"))
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
			if (character.Inventory.HasItem("BRACKEN434_SUBQ5_ITEM", 12))
			{
				character.Inventory.RemoveItem("BRACKEN434_SUBQ5_ITEM", 12);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/BRACKEN434_SUBQ1_NPC3/F_pc_drug_staup/1/BOT");
				await dialog.Msg("BRACKEN43_4_SQ5_SUCC1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

