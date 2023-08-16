//--- Melia Script -----------------------------------------------------------
// Beast's End(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70811)]
public class Quest70811Script : QuestScript
{
	protected override void Load()
	{
		SetId(70811);
		SetName("Beast's End(2)");
		SetDescription("Talk to Vilhelmas");
		SetTrack("SPossible", "ESuccess", "WHITETREES23_1_SQ12_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ11"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddObjective("kill0", "Kill 1 White Glutton", new KillObjective(58527, 1));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 145360));

		AddDialogHook("WHITETREES231_SQ_11_1", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_11_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES231_SQ_12_start", "WHITETREES23_1_SQ12"))
			{
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
			await dialog.Msg("WHITETREES231_SQ_12_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

