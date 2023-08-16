//--- Melia Script -----------------------------------------------------------
// Ready
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Schmid.
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

[QuestScript(20221)]
public class Quest20221Script : QuestScript
{
	protected override void Load()
	{
		SetId(20221);
		SetName("Ready");
		SetDescription("Talk to Epigraphist Schmid");

		AddPrerequisite(new CompletedPrerequisite("REMAIN37_SQ05"));
		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("kill0", "Kill 10 Stumpy Tree(s) or Tama(s) or Tree Ambulo(s)", new KillObjective(10, 401761, 41448, 41249));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SMEADE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SMEADE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAIN37_SQ06_select01", "REMAIN37_SQ06", "I'll go and arrange it", "I'll wait for a while"))
			{
				case 1:
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
			await dialog.Msg("REMAIN37_SQ06_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

