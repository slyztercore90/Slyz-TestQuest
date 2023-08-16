//--- Melia Script -----------------------------------------------------------
// Behind closed doors of secret
//--- Description -----------------------------------------------------------
// Quest to Archer Master and conversation that appeared suddenly.
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

[QuestScript(19013)]
public class Quest19013Script : QuestScript
{
	protected override void Load()
	{
		SetId(19013);
		SetName("Behind closed doors of secret");
		SetDescription("Archer Master and conversation that appeared suddenly");

		// Required quest doesn't exist anymore, so disabling requirement.
/**		AddPrerequisite(new CompletedPrerequisite("KATYN_13_2_HQ_07"));
		**/
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 70 Banshee(s)", new KillObjective(400101, 70));

		AddDialogHook("KATYN_13_2_HQ_01_AMASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_13_2_HQ_03_ST", "KATYN_13_2_HQ_03", "I'll take the bet", "Decline"))
			{
				case 1:
					await dialog.Msg("KATYN_13_2_HQ_03_AC");
					await dialog.Msg("FadeOutIN/1000");
					dialog.HideNPC("KATYN_13_2_HQ_01_AMASTER");
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
			await dialog.Msg("KATYN_13_2_HQ_03_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

