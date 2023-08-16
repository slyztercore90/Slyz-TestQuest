//--- Melia Script -----------------------------------------------------------
// Treasure Trove of Knowledge
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70603)]
public class Quest70603Script : QuestScript
{
	protected override void Load()
	{
		SetId(70603);
		SetName("Treasure Trove of Knowledge");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ03"));
		AddPrerequisite(new LevelPrerequisite(274));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY416_SQ_04_start", "ABBEY41_6_SQ04", "Say that you will hurry to the library", "Ask if she can't look for the book on her own"))
			{
				case 1:
					// Func/SCR_ABBEY416_SQ_04_P;
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
			await dialog.Msg("ABBEY416_SQ_04_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

