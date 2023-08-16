//--- Melia Script -----------------------------------------------------------
// The Grave Robber in History
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50085)]
public class Quest50085Script : QuestScript
{
	protected override void Load()
	{
		SetId(50085);
		SetName("The Grave Robber in History");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ060"));
		AddPrerequisite(new LevelPrerequisite(214));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("AMANDA_69_2", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_69_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_69_SQ010_startnpc01", "UNDERFORTRESS_69_SQ010", "I'll try to find them", "Find it yourself"))
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
			await dialog.Msg("UNDER_69_SQ010_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

