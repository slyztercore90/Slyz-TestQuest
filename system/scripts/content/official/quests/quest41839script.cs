//--- Melia Script -----------------------------------------------------------
// Guardian of the Lake (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Leader.
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

[QuestScript(41839)]
public class Quest41839Script : QuestScript
{
	protected override void Load()
	{
		SetId(41839);
		SetName("Guardian of the Lake (4)");
		SetDescription("Talk to the Laker Leader");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE_27_3_SQ_7_TRACK1", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(395));

		AddObjective("kill0", "Kill 1 Ferocious Kurmis", new KillObjective(59265, 1));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_27_3_SQ_7_DLG1", "F_3CMLAKE_27_3_SQ_7", "Go to the designated area.", "I need some time to prepare."))
			{
				case 1:
					// Func/FADEFUNC;
					dialog.HideNPC("F_3CMLAKE_27_3_NPC3");
					dialog.UnHideNPC("F_3CMLAKE_27_3_NPC4");
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
			await dialog.Msg("F_3CMLAKE_27_3_SQ_7_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_3_SQ_8");
	}
}

