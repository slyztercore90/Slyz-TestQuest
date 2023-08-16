//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50357)]
public class Quest50357Script : QuestScript
{
	protected override void Load()
	{
		SetId(50357);
		SetName("Suspiciously Secretive (2)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ2"));
		AddPrerequisite(new LevelPrerequisite(357));

		AddObjective("collect0", "Collect 20 Flesh of Black Hohen Olben(s)", new CollectItemObjective("ABBEY22_5_SUBQ4_ITEM1", 20));
		AddDrop("ABBEY22_5_SUBQ4_ITEM1", 10f, "Hohen_orben_black");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_5_SUBQ3_START1", "ABBEY22_5_SQ3", "It seems complicated, but I'll try.", "Let's come up with another plan."))
			{
				case 1:
					await dialog.Msg("ABBEY22_5_SUBQ3_AGR1");
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
			if (character.Inventory.HasItem("ABBEY22_5_SUBQ4_ITEM1", 20))
			{
				character.Inventory.RemoveItem("ABBEY22_5_SUBQ4_ITEM1", 20);
				character.Quests.Complete(this.QuestId);
				dialog.AddonMessage("NOTICE_Dm_Clear", "Placed the flesh of Black Hohen Olben.");
				await dialog.Msg("EffectLocalNPC/ABBEY225_SUBQ2_NPC1/F_buff_basic034_pink/2/BOT");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

