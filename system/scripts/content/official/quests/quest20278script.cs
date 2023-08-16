//--- Melia Script -----------------------------------------------------------
// Activate the Obelisk (2)
//--- Description -----------------------------------------------------------
// Quest to Go to the Ershike Altar.
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

[QuestScript(20278)]
public class Quest20278Script : QuestScript
{
	protected override void Load()
	{
		SetId(20278);
		SetName("Activate the Obelisk (2)");
		SetDescription("Go to the Ershike Altar");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ02"));
		AddPrerequisite(new LevelPrerequisite(49));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("HUEVILLAGE_58_2_MQ03_ITEM", 1));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_MQ03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_2_MQ03_NPC", "BeforeEnd", BeforeEnd);
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "Return to the Andale Village Priest");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

