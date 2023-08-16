//--- Melia Script -----------------------------------------------------------
// Retrieve Kartu Corridor
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rangda Master.
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

[QuestScript(92000)]
public class Quest92000Script : QuestScript
{
	protected override void Load()
	{
		SetId(92000);
		SetName("Retrieve Kartu Corridor");
		SetDescription("Talk to the Rangda Master");
		SetTrack("SPossible", "ESuccess", "EP12_2_D_DCAPITAL_108_MQ01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ06"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddObjective("kill0", "Kill 12 Raganosis Guardian(s)", new KillObjective(59527, 12));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ01_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ01_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ01_DLG1", "EP12_2_D_DCAPITAL_108_MQ01", "Alright", "Let's take more careful move."))
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
			await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ02");
	}
}

