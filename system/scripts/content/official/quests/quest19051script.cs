//--- Melia Script -----------------------------------------------------------
// Crafting and Materials
//--- Description -----------------------------------------------------------
// Quest to Talk to Furry Odd.
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

[QuestScript(19051)]
public class Quest19051Script : QuestScript
{
	protected override void Load()
	{
		SetId(19051);
		SetName("Crafting and Materials");
		SetDescription("Talk to Furry Odd");

		AddPrerequisite(new CompletedPrerequisite("FTOWER44_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddDialogHook("FTOWER44_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FIRETOWER_44_HQ_01_ST", "FIRETOWER_44_HQ_01", "I'll try making it", "I don't need it"))
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
			if (character.Inventory.HasItem("misc_drakeResc", 1))
			{
				character.Inventory.RemoveItem("misc_drakeResc", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FIRETOWER_44_HQ_01_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

