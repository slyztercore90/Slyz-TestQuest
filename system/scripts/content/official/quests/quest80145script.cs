//--- Melia Script -----------------------------------------------------------
// Deranged Goddess (3)
//--- Description -----------------------------------------------------------
// Quest to Return to Kupole Serija.
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

[QuestScript(80145)]
public class Quest80145Script : QuestScript
{
	protected override void Load()
	{
		SetId(80145);
		SetName("Deranged Goddess (3)");
		SetDescription("Return to Kupole Serija");
		SetTrack("SProgress", "ESuccess", "LIMESTONE_52_3_MQ_9_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(294));

		AddObjective("kill0", "Kill 1 Starlakhan", new KillObjective(58451, 1));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 135828));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("LIMESTONE_52_3_MQ_9_succ");
			dialog.UnHideNPC("LIMESTONECAVE_52_5_DALIA");
			dialog.UnHideNPC("LIMESOTNE_52_5_WALL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

