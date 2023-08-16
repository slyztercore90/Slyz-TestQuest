//--- Melia Script -----------------------------------------------------------
// Cleaning the Strange Aura (1)
//--- Description -----------------------------------------------------------
// Quest to Look for the magic circle that needs to be enhanced.
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

[QuestScript(40210)]
public class Quest40210Script : QuestScript
{
	protected override void Load()
	{
		SetId(40210);
		SetName("Cleaning the Strange Aura (1)");
		SetDescription("Look for the magic circle that needs to be enhanced");

		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_030"));
		AddPrerequisite(new LevelPrerequisite(86));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_MAGIC01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_MAGIC01", "BeforeEnd", BeforeEnd);
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
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage("NOTICE_Dm_Clear", "The magic circle has been enhanced when you removed the 4 crystals!");
			dialog.HideNPC("FARM47_PROTECT_GEM_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

