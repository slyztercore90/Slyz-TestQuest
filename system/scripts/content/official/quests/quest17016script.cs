//--- Melia Script -----------------------------------------------------------
// Scream in the Silence
//--- Description -----------------------------------------------------------
// Quest to Find the suspicious table.
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

[QuestScript(17016)]
public class Quest17016Script : QuestScript
{
	protected override void Load()
	{
		SetId(17016);
		SetName("Scream in the Silence");
		SetDescription("Find the suspicious table");
		SetTrack("SProgress", "ESuccess", "FTOWER43_SQ_05_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("kill0", "Kill 1 Gray Golem", new KillObjective(57120, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER43_SQ_05_ST", "FTOWER43_SQ_05", "Seems strange but let's help", "Pretend you didn't hear it"))
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
			await dialog.Msg("FTOWER43_SQ_05_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

