//--- Melia Script -----------------------------------------------------------
// Information about Saugas (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Eta.
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

[QuestScript(8045)]
public class Quest8045Script : QuestScript
{
	protected override void Load()
	{
		SetId(8045);
		SetName("Information about Saugas (2)");
		SetDescription("Talk to Mercenary Eta");

		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q08"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("collect0", "Collect 3 Monster Poison(s)", new CollectItemObjective("ROKAS26_SAURBLOOD", 3));
		AddDrop("ROKAS26_SAURBLOOD", 3f, 41446, 57038, 57621, 57619);

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_EHTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_EHTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("ROKAS26_SAURBLOOD", 3))
			{
				character.Inventory.RemoveItem("ROKAS26_SAURBLOOD", 3);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("ROKAS26_SUB_Q09_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Exclaimation", "You need poison from monsters to amplify the energy of the stones!", 8);
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_SUB_Q10");
	}
}

