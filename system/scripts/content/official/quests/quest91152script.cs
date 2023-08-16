//--- Melia Script -----------------------------------------------------------
// Magic Control (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91152)]
public class Quest91152Script : QuestScript
{
	protected override void Load()
	{
		SetId(91152);
		SetName("Magic Control (6)");
		SetDescription("Talk to Pajauta");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE2_MQ_9_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(475));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_2_PAJAUTA2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_2_PAJAUTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE2_MQ_9_DLG1", "EP14_2_DCASTLE2_MQ_9", "Alright", "We need to reorganize."))
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
			await dialog.Msg("EP14_2_DCASTLE2_MQ_9_DLG3");
			dialog.UnHideNPC("EP14_2_2_LAMIN2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

