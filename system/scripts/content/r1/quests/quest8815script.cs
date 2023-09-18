//--- Melia Script -----------------------------------------------------------
// The Last Collection
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Gofden.
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

[QuestScript(8815)]
public class Quest8815Script : QuestScript
{
	protected override void Load()
	{
		SetId(8815);
		SetName("The Last Collection");
		SetDescription("Talk to Guard Gofden");

		AddPrerequisite(new LevelPrerequisite(187));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_GOFDEN", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_GOFDEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_03_01", "FLASH60_SQ_03", "I will collect the keepsakes", "About the Royal Army guards and the Knights of Kaliss", "That will be hard"))
		{
			case 1:
				dialog.UnHideNPC("FLASH60_SQ_03");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH60_SQ_03_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH60_SQ_03_03");
		dialog.HideNPC("FLASH60_SQ_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

