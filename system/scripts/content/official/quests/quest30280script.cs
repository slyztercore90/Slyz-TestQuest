//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (6)
//--- Description -----------------------------------------------------------
// Quest to Spray Monsters with the Special Solution and Defeat Them.
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

[QuestScript(30280)]
public class Quest30280Script : QuestScript
{
	protected override void Load()
	{
		SetId(30280);
		SetName("Finding a Cure for the Epidemic (6)");
		SetDescription("Spray Monsters with the Special Solution and Defeat Them");

		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(322));

		AddObjective("kill0", "Kill 9 Kugheri Symbani(s) or Kugheri Balzer(s) or Kugheri Zeffi(s)", new KillObjective(9, 58550, 58553, 58554));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("WTREES_21_2_SQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

