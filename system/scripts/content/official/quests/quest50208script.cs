//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (7)
//--- Description -----------------------------------------------------------
// Quest to Find Oscaras.
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

[QuestScript(50208)]
public class Quest50208Script : QuestScript
{
	protected override void Load()
	{
		SetId(50208);
		SetName("Danger the Lurks in the Forest (7)");
		SetDescription("Find Oscaras");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ6"));
		AddPrerequisite(new LevelPrerequisite(310));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14260));

		AddDialogHook("BRACKEN432_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BRACKEN43_2_SQ7_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("BRACKEN432_SUBQ_NPC2");
	}
}

