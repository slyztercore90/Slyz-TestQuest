//--- Melia Script -----------------------------------------------------------
// Young Magician Owyn (2)
//--- Description -----------------------------------------------------------
// Quest to Owyn's Request.
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

[QuestScript(17003)]
public class Quest17003Script : QuestScript
{
	protected override void Load()
	{
		SetId(17003);
		SetName("Young Magician Owyn (2)");
		SetDescription("Owyn's Request");

		AddPrerequisite(new CompletedPrerequisite("FTOWER41_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("kill0", "Kill 10 Drake(s)", new KillObjective(401621, 10));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER41_SQ_02_ST", "FTOWER41_SQ_02", "I'll take care of Drake", "Well then, I shall get going. Goodbye."))
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
			await dialog.Msg("FTOWER41_SQ_02_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

