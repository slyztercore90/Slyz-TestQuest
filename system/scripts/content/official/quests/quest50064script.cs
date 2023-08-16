//--- Melia Script -----------------------------------------------------------
// Special Powers Discovered by the Monocle (2)
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

[QuestScript(50064)]
public class Quest50064Script : QuestScript
{
	protected override void Load()
	{
		SetId(50064);
		SetName("Special Powers Discovered by the Monocle (2)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ010"));
		AddPrerequisite(new LevelPrerequisite(207));

		AddObjective("kill0", "Kill 10 Brown Rambear(s) or Brown Rambear Archer(s) or Brown Rambear Magician(s)", new KillObjective(10, 57964, 57965, 57966));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("AMANDA_67_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_67_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER67_MQ020_startnpc01", "UNDERFORTRESS_67_MQ020", "Alright", "Tell him to look for it later"))
			{
				case 1:
					await dialog.Msg("UNDER67_MQ020_startnpc02");
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
			await dialog.Msg("UNDER67_MQ020_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

