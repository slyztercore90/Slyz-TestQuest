//--- Melia Script -----------------------------------------------------------
// Purification by Holy Water
//--- Description -----------------------------------------------------------
// Quest to Talk to the Royal Soldier Spirit.
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

[QuestScript(72226)]
public class Quest72226Script : QuestScript
{
	protected override void Load()
	{
		SetId(72226);
		SetName("Purification by Holy Water");
		SetDescription("Talk to the Royal Soldier Spirit");

		AddPrerequisite(new CompletedPrerequisite("CASTLE94_MAIN03"));
		AddPrerequisite(new LevelPrerequisite(395));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20882));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_MAIN02", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE94_NPC_MAIN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE94_MAIN04_01", "CASTLE94_MAIN04", "Alright", "I'm feeling a little sluggish all of a sudden."))
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CASTLE94_MAIN04_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

