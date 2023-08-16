//--- Melia Script -----------------------------------------------------------
// Goddess Jurate's Loremaster (1)
//--- Description -----------------------------------------------------------
// Quest to Check the situation of the Lemyra Sentry.
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

[QuestScript(90069)]
public class Quest90069Script : QuestScript
{
	protected override void Load()
	{
		SetId(90069);
		SetName("Goddess Jurate's Loremaster (1)");
		SetDescription("Check the situation of the Lemyra Sentry");
		SetTrack("SProgress", "ESuccess", "CORAL_32_2_SQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("kill0", "Kill 8 Blue Colimen(s)", new KillObjective(57947, 8));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 1));

		AddDialogHook("CORAL_32_2_SQ_1_NOTICE", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_DARUL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BalloonText/CORAL_32_2_SQ_1_ST/5", "CORAL_32_2_SQ_1"))
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
			await dialog.Msg("CORAL_32_2_SQ_1_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

