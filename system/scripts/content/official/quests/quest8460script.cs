//--- Melia Script -----------------------------------------------------------
// New Market District (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Canolyn.
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

[QuestScript(8460)]
public class Quest8460Script : QuestScript
{
	protected override void Load()
	{
		SetId(8460);
		SetName("New Market District (2)");
		SetDescription("Talk to Stonemason Canolyn");
		SetTrack("SProgress", "ESuccess", "REMAINS40_SQ_02_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("REMAINS40_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("kill0", "Kill 1 Moa", new KillObjective(41378, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("misc_liena_top_2", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS40_SQ_02_01", "REMAINS40_SQ_02", "Which monster's act is it?", "I better get going."))
			{
				case 1:
					await dialog.Msg("REMAINS40_SQ_02_01_Q");
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
			await dialog.Msg("REMAINS40_SQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

