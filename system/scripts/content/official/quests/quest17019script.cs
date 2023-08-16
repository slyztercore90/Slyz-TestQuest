//--- Melia Script -----------------------------------------------------------
// Transmuter Furry Odd (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Transmuter Furry Odd.
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

[QuestScript(17019)]
public class Quest17019Script : QuestScript
{
	protected override void Load()
	{
		SetId(17019);
		SetName("Transmuter Furry Odd (3)");
		SetDescription("Talk to Transmuter Furry Odd");
		SetTrack("SProgress", "ESuccess", "FTOWER44_SQ_03_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("FTOWER44_SQ_02"));
		AddPrerequisite(new LevelPrerequisite(123));

		AddObjective("kill0", "Kill 1 Yonazolem", new KillObjective(57420, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER44_SQ_03_ST", "FTOWER44_SQ_03", "Sure, I'll defeat it", "Let's just run away"))
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
			await dialog.Msg("FTOWER44_SQ_03_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

