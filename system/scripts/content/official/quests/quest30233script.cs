//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (3)
//--- Description -----------------------------------------------------------
// Quest to Search the Command Room for Maintanence documents for Inner Wall District 9.
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

[QuestScript(30233)]
public class Quest30233Script : QuestScript
{
	protected override void Load()
	{
		SetId(30233);
		SetName("Inspect Inner Wall District 9 (3)");
		SetDescription("Search the Command Room for Maintanence documents for Inner Wall District 9");

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_2"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("CASTLE_20_2_SQ_3_ITEM", 1))
			{
				character.Inventory.RemoveItem("CASTLE_20_2_SQ_3_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CASTLE_20_2_SQ_3_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Scroll", "Inspect the Command Room and find the files Kupole Liepa talked about.");
	}
}

