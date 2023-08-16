//--- Melia Script -----------------------------------------------------------
// Crystal Stone at the Rest Place
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72101)]
public class Quest72101Script : QuestScript
{
	protected override void Load()
	{
		SetId(72101);
		SetName("Crystal Stone at the Rest Place");
		SetDescription("Talk to the Beholder");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ01"));
		AddPrerequisite(new LevelPrerequisite(333));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE261_SQ02_DLG01", "F_3CMLAKE261_SQ02", "I'll take care of it.", "I'm afraid I can't."))
			{
				case 1:
					await dialog.Msg("3CMLAKE261_SQ02_DLG02");
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
			await dialog.Msg("3CMLAKE261_SQ02_DLG04");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

