//--- Melia Script -----------------------------------------------------------
// The Enemies That Remain
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

[QuestScript(70611)]
public class Quest70611Script : QuestScript
{
	protected override void Load()
	{
		SetId(70611);
		SetName("The Enemies That Remain");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ09"));
		AddPrerequisite(new LevelPrerequisite(274));

		AddObjective("kill0", "Kill 18 Red Nuo(s)", new KillObjective(57984, 18));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY416_SQ_11_start", "ABBEY41_6_SQ11", "Say that you'll finish the job", "I'm going to rest for a while."))
			{
				case 1:
					await dialog.Msg("ABBEY416_SQ_11_agree");
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
			await dialog.Msg("ABBEY416_SQ_11_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

