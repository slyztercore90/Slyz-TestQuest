//--- Melia Script -----------------------------------------------------------
// What is the Relic
//--- Description -----------------------------------------------------------
// Quest to Talk to the Recovery Squad Adjutant.
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

[QuestScript(41820)]
public class Quest41820Script : QuestScript
{
	protected override void Load()
	{
		SetId(41820);
		SetName("What is the Relic");
		SetDescription("Talk to the Recovery Squad Adjutant");
		SetTrack("SPossible", "ESuccess", "F_3CMLAKE_27_1_SQ_10_TRACK1", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_9"));
		AddPrerequisite(new LevelPrerequisite(388));

		AddObjective("kill0", "Kill 1 Tenacious Tutu", new KillObjective(59263, 1));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC7", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_27_1_SQ_10_DLG1", "F_3CMLAKE_27_1_SQ_10", "I'll look around.", "I don't sense anything."))
			{
				case 1:
					dialog.HideNPC("F_3CMLAKE_27_1_NPC3");
					dialog.UnHideNPC("F_3CMLAKE_27_1_NPC5");
					dialog.UnHideNPC("F_3CMLAKE_27_1_NPC6");
					dialog.UnHideNPC("F_3CMLAKE_27_1_NPC7");
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
			await dialog.Msg("F_3CMLAKE_27_1_SQ_10_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_11");
	}
}

