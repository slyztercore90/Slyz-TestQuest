//--- Melia Script -----------------------------------------------------------
// Activities of a Wizard [Wizard Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(17600)]
public class Quest17600Script : QuestScript
{
	protected override void Load()
	{
		SetId(17600);
		SetName("Activities of a Wizard [Wizard Advancement]");
		SetDescription("Talk to the Wizard Master");
		SetTrack("SProgress", "ESuccess", "JOB_WIZARD4_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Golem", new KillObjective(57162, 1));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_WIZARD4_1_select", "JOB_WIZARD4_1", "I will take the test", "Cancel"))
			{
				case 1:
					await dialog.Msg("JOB_WIZARD4_1_agree");
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
			await dialog.Msg("JOB_WIZARD4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

