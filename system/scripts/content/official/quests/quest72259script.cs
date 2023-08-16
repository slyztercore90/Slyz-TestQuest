//--- Melia Script -----------------------------------------------------------
// Message of the Goddesses
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72259)]
public class Quest72259Script : QuestScript
{
	protected override void Load()
	{
		SetId(72259);
		SetName("Message of the Goddesses");
		SetDescription("Talk to Neringa");
		SetTrack("SPossible", "ESuccess", "DCAPITAL53_1_MQ_06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL53_1_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(441));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL53_1_MQ_06_DLG01", "DCAPITAL53_1_MQ_06", "Alright", "End conversation"))
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
			await dialog.Msg("DCAPITAL53_1_MQ_06_DLG05");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			// Func/SCR_DCAPITAL53_1_MQ_06_MOVE_FIELD;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

