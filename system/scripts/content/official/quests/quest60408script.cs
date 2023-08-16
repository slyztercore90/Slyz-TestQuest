//--- Melia Script -----------------------------------------------------------
// Parias Forest Post (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60408)]
public class Quest60408Script : QuestScript
{
	protected override void Load()
	{
		SetId(60408);
		SetName("Parias Forest Post (2)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_8"));
		AddPrerequisite(new LevelPrerequisite(380));

		AddReward(new ItemReward("expCard16", 1));

		AddDialogHook("PAYAUTA_EP11_NPC_232_FLLW", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_232_FLLW", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PAYAUTA_EP11_9_1", "PAYAUTA_EP11_9", "I am ready", "Please wait"))
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
			await dialog.Msg("PAYAUTA_EP11_9_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

