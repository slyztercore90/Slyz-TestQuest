//--- Melia Script -----------------------------------------------------------
// Storage Lamp(3)
//--- Description -----------------------------------------------------------
// Quest to Check the Red Lamp.
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

[QuestScript(30159)]
public class Quest30159Script : QuestScript
{
	protected override void Load()
	{
		SetId(30159);
		SetName("Storage Lamp(3)");
		SetDescription("Check the Red Lamp");

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_5"));

		AddObjective("collect0", "Collect 10 Oil for the Red Lamp(s)", new CollectItemObjective("PRISON_79_MQ_6_ITEM", 10));
		AddDrop("PRISON_79_MQ_6_ITEM", 10f, 57983, 57932, 57951);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_OBJ_5", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_OBJ_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("PRISON_79_MQ_6_ITEM", 10))
		{
			character.Inventory.RemoveItem("PRISON_79_MQ_6_ITEM", 10);
			dialog.UnHideNPC("PRISON_79_OBJ_5_EFFECT");
			character.Quests.Complete(this.QuestId);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have lit the Red Lamp{nl}Return to Zanas' Spirit");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

