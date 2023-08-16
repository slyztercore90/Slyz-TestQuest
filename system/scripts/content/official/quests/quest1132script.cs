//--- Melia Script -----------------------------------------------------------
// Where the Sun Shines [Pyromancer Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(1132)]
public class Quest1132Script : QuestScript
{
	protected override void Load()
	{
		SetId(1132);
		SetName("Where the Sun Shines [Pyromancer Advancement] (1)");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_PYROMANCER3_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(57154, 1));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PYROMANCER3_1_select1", "JOB_PYROMANCER3_1", "I'll do it", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_PYROMANCER3_1_prog1");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PYROMANCER3_2");
	}
}

