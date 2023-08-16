//--- Melia Script -----------------------------------------------------------
// Divide and rule (2)
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(92022)]
public class Quest92022Script : QuestScript
{
	protected override void Load()
	{
		SetId(92022);
		SetName("Divide and rule (2)");
		SetDescription("Speak with Goddess Lada");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(456));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_4_MQ_05_MAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_4_MQ_05_DLG1", "EP13_F_SIAULIAI_4_MQ_05", "I'll hand it over and return", "There are still some things to do"))
			{
				case 1:
					dialog.UnHideNPC("EP13_F_SIAULIAI_4_MQ_05_MAIL");
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
			await dialog.Msg("EP13_F_SIAULIAI_4_MQ_05_DLG2");
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("EP13_F_SIAULIAI_4_MQ_05_MAIL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_4_MQ_06");
	}
}

