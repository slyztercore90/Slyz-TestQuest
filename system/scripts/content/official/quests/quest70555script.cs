//--- Melia Script -----------------------------------------------------------
// Demons must disappear
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Dorma.
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

[QuestScript(70555)]
public class Quest70555Script : QuestScript
{
	protected override void Load()
	{
		SetId(70555);
		SetName("Demons must disappear");
		SetDescription("Talk to Monk Dorma");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ13"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddObjective("kill0", "Kill 10 Yellow Dumaro(s)", new KillObjective(57992, 10));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_02_1", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_02_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM414_SQ_16_start", "PILGRIM41_4_SQ16", "Say that you will deal with the Demons", "I can only help so much"))
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
			await dialog.Msg("PILGRIM414_SQ_16_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

