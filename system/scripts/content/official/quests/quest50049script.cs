//--- Melia Script -----------------------------------------------------------
// Drawing Attention (1)
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

[QuestScript(50049)]
public class Quest50049Script : QuestScript
{
	protected override void Load()
	{
		SetId(50049);
		SetName("Drawing Attention (1)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_65_MQ010"));
		AddPrerequisite(new LevelPrerequisite(200));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("AMANDA_65_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_65_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS_65_MQ020_startnpc01", "UNDERFORTRESS_65_MQ020", "Do you have any plans?", "The Resounding Bomb may be dangerous"))
			{
				case 1:
					await dialog.Msg("UNDER_65_MQ020_startnpc02");
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
			await dialog.Msg("UNDERFORTRESS_65_MQ020_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

