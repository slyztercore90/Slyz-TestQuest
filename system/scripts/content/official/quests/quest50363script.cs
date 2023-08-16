//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (8)
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

[QuestScript(50363)]
public class Quest50363Script : QuestScript
{
	protected override void Load()
	{
		SetId(50363);
		SetName("Suspiciously Secretive (8)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ8"));
		AddPrerequisite(new LevelPrerequisite(357));

		AddObjective("collect0", "Collect 15 Essence of Harugal(s)", new CollectItemObjective("ABBEY22_5_SUBQ9_ITEM1", 15));
		AddDrop("ABBEY22_5_SUBQ9_ITEM1", 10f, "Harugal_black");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("ABBEY22_5_SUBQ9_ITEM2", 1));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY3", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_5_SUBQ9_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_5_SUBQ9_START1", "ABBEY22_5_SQ9", "I'll go and retrieve the essence.", "Never mind that. Let's just use the Registry Orb."))
			{
				case 1:
					await dialog.Msg("ABBEY22_5_SUBQ9_AGR1");
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
			if (character.Inventory.HasItem("ABBEY22_5_SUBQ9_ITEM1", 15))
			{
				character.Inventory.RemoveItem("ABBEY22_5_SUBQ9_ITEM1", 15);
				character.Quests.Complete(this.QuestId);
				dialog.AddonMessage("NOTICE_Dm_Clear", "Placed essence of Black Harugal.");
				// Func/ABBEY22_5_SUBQ8_COMP;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

