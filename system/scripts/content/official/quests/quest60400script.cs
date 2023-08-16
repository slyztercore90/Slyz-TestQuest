//--- Melia Script -----------------------------------------------------------
// Pajauta
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

[QuestScript(60400)]
public class Quest60400Script : QuestScript
{
	protected override void Load()
	{
		SetId(60400);
		SetName("Pajauta");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(380));

		AddDialogHook("PAYAUTA_EP11_NPC_CITY_1", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_87", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PAYAUTA_EP11_1_1", "PAYAUTA_EP11_1", "Follow.", "Decline"))
			{
				case 1:
					await dialog.Msg("PAYAUTA_EP11_1_2");
					await dialog.Msg("FadeOutIN/3000");
					dialog.HideNPC("PAYAUTA_EP11_NPC_CITY_1");
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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
			await dialog.Msg("PAYAUTA_EP11_1_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

