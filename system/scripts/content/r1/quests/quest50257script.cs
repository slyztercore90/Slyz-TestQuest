//--- Melia Script -----------------------------------------------------------
// Forgotten Refugees
//--- Description -----------------------------------------------------------
// Quest to Talk to Curtis.
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

[QuestScript(50257)]
public class Quest50257Script : QuestScript
{
	protected override void Load()
	{
		SetId(50257);
		SetName("Forgotten Refugees");
		SetDescription("Talk to Curtis");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES56_1_SQ9"));

		AddReward(new ItemReward("Gacha_G_009", 1));

		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ10_START1", "WHITETREES56_1_SQ10", "I will go get some help.", "I will think about it"))
		{
			case 1:
				await dialog.Msg("WHITETREES561_SUBQ10_AGREE1");
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

		await dialog.Msg("WHITETREES561_SUBQ10_SUCC1");
		// Func/WHITETREES561_SQ10_UNLOCK_SSN_KILL;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

