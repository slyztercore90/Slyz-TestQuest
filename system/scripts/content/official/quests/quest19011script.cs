//--- Melia Script -----------------------------------------------------------
// Behind closed doors of secret
//--- Description -----------------------------------------------------------
// Quest to Suddenly appeared Swordsman master and conversation.
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

[QuestScript(19011)]
public class Quest19011Script : QuestScript
{
	protected override void Load()
	{
		SetId(19011);
		SetName("Behind closed doors of secret");
		SetDescription("Suddenly appeared Swordsman master and conversation");

		// Required quest doesn't exist anymore, so disabling requirement.
/**		AddPrerequisite(new CompletedPrerequisite("KATYN_13_2_HQ_05"));
		**/
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 70 Banshee(s)", new KillObjective(400101, 70));

		AddDialogHook("KATYN_13_2_HQ_01_SMASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_13_2_HQ_01_ST", "KATYN_13_2_HQ_01", "I will take the test", "Decline"))
			{
				case 1:
					await dialog.Msg("KATYN_13_2_HQ_01_AC");
					await dialog.Msg("FadeOutIN/1000");
					dialog.HideNPC("KATYN_13_2_HQ_01_SMASTER");
					// Func/DESTROY_SESSION;
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
			await dialog.Msg("KATYN_13_2_HQ_01_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

