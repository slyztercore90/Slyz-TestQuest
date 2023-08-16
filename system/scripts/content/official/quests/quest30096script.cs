//--- Melia Script -----------------------------------------------------------
// Ranger On-Site Training [ Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Submaster.
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

[QuestScript(30096)]
public class Quest30096Script : QuestScript
{
	protected override void Load()
	{
		SetId(30096);
		SetName("Ranger On-Site Training [ Ranger Advancement]");
		SetDescription("Talk to the Ranger Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_2_RANGER_4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(57152, 1));

		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_RANGER_4_1_select", "JOB_2_RANGER_4_1", "I will show you my skills", "If it can't be helped, then it can't be helped"))
			{
				case 1:
					await dialog.Msg("JOB_2_RANGER_4_1_agree");
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
			await dialog.Msg("JOB_2_RANGER_4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

