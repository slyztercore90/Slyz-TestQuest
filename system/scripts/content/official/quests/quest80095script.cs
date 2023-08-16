//--- Melia Script -----------------------------------------------------------
// For Total Freedom (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elgos Abbot.
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

[QuestScript(80095)]
public class Quest80095Script : QuestScript
{
	protected override void Load()
	{
		SetId(80095);
		SetName("For Total Freedom (1)");
		SetDescription("Talk to the Elgos Abbot");
		SetTrack("SProgress", "ESuccess", "ABBEY_35_4_SQ_7_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(232));

		AddObjective("kill0", "Kill 1 Glutton", new KillObjective(58428, 1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY_35_4_SQ_7_start", "ABBEY_35_4_SQ_7", "I will certainly help", "Please wait little more"))
			{
				case 1:
					await dialog.Msg("ABBEY_35_4_SQ_7_add");
					dialog.UnHideNPC("ABBEY_35_4_DOMINIKAS");
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
			await dialog.Msg("ABBEY_35_4_SQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

