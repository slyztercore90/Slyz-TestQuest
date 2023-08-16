//--- Melia Script -----------------------------------------------------------
// Undercover Operation
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Simonas.
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

[QuestScript(90025)]
public class Quest90025Script : QuestScript
{
	protected override void Load()
	{
		SetId(90025);
		SetName("Undercover Operation");
		SetDescription("Talk to Merchant Simonas");
		SetTrack("SProgress", "ESuccess", "CORAL_32_1_SQ_6_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(232));

		AddObjective("kill0", "Kill 1 Carapace", new KillObjective(107000, 1));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 75168));

		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_32_1_SQ_6_ST", "CORAL_32_1_SQ_6", "Ask what you should do", "I think that's a shot in the dark."))
			{
				case 1:
					await dialog.Msg("CORAL_32_1_SQ_6_AG");
					// Func/SCR_CORAL_32_1_SQ_6_NPC_RUN;
					dialog.HideNPC("CORAL_32_1_PEOPLE1");
					dialog.HideNPC("CORAL_32_1_GUARD3");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("CORAL_32_1_SQ_6_SU");
			dialog.UnHideNPC("CORAL_32_1_GUARD4");
			dialog.UnHideNPC("CORAL_32_1_SERVANT");
			dialog.UnHideNPC("CORAL_32_1_GUARD5");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

