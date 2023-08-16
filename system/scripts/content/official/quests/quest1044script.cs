//--- Melia Script -----------------------------------------------------------
// Enter the Miners' Village
//--- Description -----------------------------------------------------------
// Quest to Return to Knight Aras.
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

[QuestScript(1044)]
public class Quest1044Script : QuestScript
{
	protected override void Load()
	{
		SetId(1044);
		SetName("Enter the Miners' Village");
		SetDescription("Return to Knight Aras");
		SetTrack("SProgress", "ESuccess", "SIAUL_EAST_REQUEST7_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST6"));
		AddPrerequisite(new LevelPrerequisite(7));

		AddObjective("kill0", "Kill 7 Vubbe Scout(s) or Novice Vubbe Archer(s)", new KillObjective(7, 57192, 57193));

		AddReward(new ExpReward(3000, 3000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 1092));

		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_EAST_REQUEST7_dlg1", "SIAUL_EAST_REQUEST7", "I would like to go to the Miners' Village", "Give me some time to prepare"))
			{
				case 1:
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
			await dialog.Msg("SIAUL_EAST_REQUEST7_dlg5");
			dialog.HideNPC("JOB_LINKER2_1_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

