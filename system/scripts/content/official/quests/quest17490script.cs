//--- Melia Script -----------------------------------------------------------
// Training Body and Mind [Monk Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Monk Master.
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

[QuestScript(17490)]
public class Quest17490Script : QuestScript
{
	protected override void Load()
	{
		SetId(17490);
		SetName("Training Body and Mind [Monk Advancement]");
		SetDescription("Meet the Monk Master");
		SetTrack("SProgress", "ESuccess", "JOB_MONK4_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Monk Master", new KillObjective(57225, 1));

		AddDialogHook("JOB_MONK4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_MONK4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_MONK4_1_ST", "JOB_MONK4_1", "Accept the duel with the Master", "Avoid the duel"))
			{
				case 1:
					await dialog.Msg("JOB_MONK4_1_agree");
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
			await dialog.Msg("JOB_MONK4_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

