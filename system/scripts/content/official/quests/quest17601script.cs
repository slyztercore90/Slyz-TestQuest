//--- Melia Script -----------------------------------------------------------
// Piercing Through [Cataphract Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cataphract Submaster.
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

[QuestScript(17601)]
public class Quest17601Script : QuestScript
{
	protected override void Load()
	{
		SetId(17601);
		SetName("Piercing Through [Cataphract Advancement]");
		SetDescription("Talk to the Cataphract Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_CATAPHRACT4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(57159, 1));

		AddDialogHook("MASTER_CATAPHRACT", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CATAPHRACT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_CATAPHRACT4_1_select", "JOB_CATAPHRACT4_1", "I will take the test", "Cancel"))
			{
				case 1:
					await dialog.Msg("JOB_CATAPHRACT4_1_agree");
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
			await dialog.Msg("JOB_CATAPHRACT4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

