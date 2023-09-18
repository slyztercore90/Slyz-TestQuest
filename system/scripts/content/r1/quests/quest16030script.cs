//--- Melia Script -----------------------------------------------------------
// Brewer's Last Hope
//--- Description -----------------------------------------------------------
// Quest to Talk to Brewer Dorjen.
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

[QuestScript(16030)]
public class Quest16030Script : QuestScript
{
	protected override void Load()
	{
		SetId(16030);
		SetName("Brewer's Last Hope");
		SetDescription("Talk to Brewer Dorjen");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_03"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MQ04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_MQ04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_4_MQ_04_select", "SIAULIAI_46_4_MQ_04", "Calm down", "About the other Revelator", "He's not going to calm down. Let's just go."))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_4_MQ_04_start_prog");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_4_MQ_04_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("SIAULIAI_46_4_MQ_04_ITEM", 1))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_4_MQ_04_ITEM", 1);
			await dialog.Msg("SIAULIAI_46_4_MQ_04_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_4_MQ_05");
	}
}

