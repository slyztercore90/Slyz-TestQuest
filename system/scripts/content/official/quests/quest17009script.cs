//--- Melia Script -----------------------------------------------------------
// Sealed Soul (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17009)]
public class Quest17009Script : QuestScript
{
	protected override void Load()
	{
		SetId(17009);
		SetName("Sealed Soul (2)");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new CompletedPrerequisite("FTOWER42_SQ_02"));
		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 10 Experimental Slime(s)", new KillObjective(47402, 10));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER42_SQ_03_ST", "FTOWER42_SQ_03", "Alright, I'll help you", "Ignore"))
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
			await dialog.Msg("FTOWER42_SQ_03_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER42_SQ_04");
	}
}

