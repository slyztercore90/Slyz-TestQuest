//--- Melia Script -----------------------------------------------------------
// Join
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91134)]
public class Quest91134Script : QuestScript
{
	protected override void Load()
	{
		SetId(91134);
		SetName("Join");
		SetDescription("Talk to the General Ramin");
		SetTrack("SPossible", "ESuccess", "EP14_2_DCASTLE1_MQ_1_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("ep14_2_START_quest"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_Lamin1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_Lamin1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE1_MQ_1_DLG1", "EP14_2_DCASTLE1_MQ_1", "Alright", "I'm busy at the moment."))
			{
				case 1:
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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
			await dialog.Msg("EP14_2_DCASTLE1_MQ_1_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_2");
	}
}

