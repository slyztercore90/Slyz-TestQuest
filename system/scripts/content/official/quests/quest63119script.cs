//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (15)
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Entry Officer.
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

[QuestScript(63119)]
public class Quest63119Script : QuestScript
{
	protected override void Load()
	{
		SetId(63119);
		SetName("Revelator of Moroth (15)");
		SetDescription("Talk to Orsha Entry Officer");
		SetTrack("SProgress", "ESuccess", "EP14_3LINE_TUTO_MQ_15_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_14"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("EP14_F_CORAL_RAID_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_3LINE_TUTO_MQ_15_5", "EP14_3LINE_TUTO_MQ_15", "I'm a Revelator.", "It's nothing."))
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
			await dialog.Msg("EP14_3LINE_TUTO_MQ_15_1");
			await dialog.Msg("FadeOutIN/3000");
			await dialog.Msg("EP14_3LINE_TUTO_MQ_15_2");
			await dialog.Msg("EP14_3LINE_TUTO_MQ_15_3");
			await dialog.Msg("EP14_3LINE_TUTO_MQ_15_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

