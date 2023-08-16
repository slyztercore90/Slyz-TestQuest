//--- Melia Script -----------------------------------------------------------
// Sacred or Secular (2)
//--- Description -----------------------------------------------------------
// Quest to Go to the altar Believer Jaonus talked about..
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

[QuestScript(90087)]
public class Quest90087Script : QuestScript
{
	protected override void Load()
	{
		SetId(90087);
		SetName("Sacred or Secular (2)");
		SetDescription("Go to the altar Believer Jaonus talked about.");
		SetTrack("SProgress", "ESuccess", "CATACOMB_25_4_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(292));

		AddObjective("kill0", "Kill 8 Yellow Pag Clamper(s)", new KillObjective(58501, 8));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CATACOMB_25_4_SQ_50_SU");
			dialog.UnHideNPC("CATACOMB_25_4_SQ_KOSTAS");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_CATACOMB_25_4_SQ_40_START;
	}
}

