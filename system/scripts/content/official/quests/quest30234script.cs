//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
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

[QuestScript(30234)]
public class Quest30234Script : QuestScript
{
	protected override void Load()
	{
		SetId(30234);
		SetName("Inspect Inner Wall District 9 (4)");
		SetDescription("Talk to Kupole Liepa");

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE_20_2_SQ_4_select", "CASTLE_20_2_SQ_4", "I will return with it as soon as possible.", "I don't know what you are saying"))
			{
				case 1:
					await dialog.Msg("CASTLE_20_2_SQ_4_agree");
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
			if (character.Inventory.HasItem("CASTLE_20_2_SQ_4_ITEM", 1))
			{
				character.Inventory.RemoveItem("CASTLE_20_2_SQ_4_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CASTLE_20_2_SQ_4_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

