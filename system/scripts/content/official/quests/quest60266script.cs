//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (4)
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

[QuestScript(60266)]
public class Quest60266Script : QuestScript
{
	protected override void Load()
	{
		SetId(60266);
		SetName("The History that Will Not Be Recorded (4)");
		SetDescription("Talk to Neringa");
		SetTrack("SProgress", "ESuccess", "FANTASYLIB484_MQ_4_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_3"));
		AddPrerequisite(new LevelPrerequisite(344));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB484_MQ_4_1", "FANTASYLIB484_MQ_4", "I'll follow the instructions.", "I need to prepare"))
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
			await dialog.Msg("FANTASYLIB484_MQ_4_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

