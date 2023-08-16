//--- Melia Script -----------------------------------------------------------
// The Glory of a Gladiator [Murmillo Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Murmillo Master.
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

[QuestScript(90158)]
public class Quest90158Script : QuestScript
{
	protected override void Load()
	{
		SetId(90158);
		SetName("The Glory of a Gladiator [Murmillo Advancement]");
		SetDescription("Talk with the Murmillo Master");
		SetTrack("SProgress", "ESuccess", "JOB_MURMILLO_8_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 1 Silva Griffin", new KillObjective(107017, 1));

		AddDialogHook("MURMILO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MURMILO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_MURMILLO_8_1_ST", "JOB_MURMILLO_8_1", "Tell him you would challenge for it", "I need some time to think about it."))
			{
				case 1:
					await dialog.Msg("JOB_MURMILLO_8_1_AG");
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
			await dialog.Msg("JOB_MURMILLO_8_1_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

