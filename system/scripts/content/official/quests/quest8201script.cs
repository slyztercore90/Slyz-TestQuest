//--- Melia Script -----------------------------------------------------------
// Memorial Service (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(8201)]
public class Quest8201Script : QuestScript
{
	protected override void Load()
	{
		SetId(8201);
		SetName("Memorial Service (2)");
		SetDescription("Talk to the Weak Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(109));

		AddObjective("collect0", "Collect 8 Soldiers' Belongings(s)", new CollectItemObjective("KATYN72_GHOSTBAG", 8));
		AddDrop("KATYN72_GHOSTBAG", 7f, "ellomago");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN72_MQ_02_01", "KATYN72_MQ_02", "I will get back their belongings", "I can only help so much"))
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
			if (character.Inventory.HasItem("KATYN72_GHOSTBAG", 8))
			{
				character.Inventory.RemoveItem("KATYN72_GHOSTBAG", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("KATYN72_MQ_02_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN72_MQ_03");
	}
}

