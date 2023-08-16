//--- Melia Script -----------------------------------------------------------
// Special Powers Discovered by the Monocle (3)
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

[QuestScript(50065)]
public class Quest50065Script : QuestScript
{
	protected override void Load()
	{
		SetId(50065);
		SetName("Special Powers Discovered by the Monocle (3)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ020"));
		AddPrerequisite(new LevelPrerequisite(207));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));

		AddDialogHook("AMANDA_67_2", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_67_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_67_MQ030_startnpc01", "UNDERFORTRESS_67_MQ030", "Try using the monocle", "There's probably nothing of importance"))
			{
				case 1:
					// Func/UNDER67_AMANDA_LOOK_AROUND;
					await dialog.Msg("UNDER_67_MQ030_startnpc02");
					dialog.UnHideNPC("EMINENT_67_1");
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
			await dialog.Msg("UNDER_67_MQ030_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

