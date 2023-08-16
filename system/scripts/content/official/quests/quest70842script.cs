//--- Melia Script -----------------------------------------------------------
// Demon Orders
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(70842)]
public class Quest70842Script : QuestScript
{
	protected override void Load()
	{
		SetId(70842);
		SetName("Demon Orders");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ02"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("WHITETREES23_3_SQ03_ITEM", 1))
			{
				character.Inventory.RemoveItem("WHITETREES23_3_SQ03_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("WHITETREES233_SQ_03_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Clear", "You have found Demon Orders{nl}Indraja might be able to make sense of it.");
	}
}

