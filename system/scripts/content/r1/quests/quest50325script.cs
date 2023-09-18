//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (11)
//--- Description -----------------------------------------------------------
// Quest to Talk to Indrea.
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

[QuestScript(50325)]
public class Quest50325Script : QuestScript
{
	protected override void Load()
	{
		SetId(50325);
		SetName("I Can Hear You Singing (11)");
		SetDescription("Talk to Indrea");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ9"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES221_SUBQ_NPC6", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ10_START1", "WTREES22_1_SQ10", "Try it yourself.", "Just go"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("WTREES22_1_SUBQ10_SUCC1");
		dialog.HideNPC("WTREES221_SUBQ_NPC6");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

