//--- Melia Script -----------------------------------------------------------
// Giltine's Rival (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80447)]
public class Quest80447Script : QuestScript
{
	protected override void Load()
	{
		SetId(80447);
		SetName("Giltine's Rival (1)");
		SetDescription("Talk to Goddess Austeja");
		SetTrack("SPossible", "ESuccess", "D_CASTLE_19_1_MQ_06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(421));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("D_CASTLE_19_1_MQ_06_ST", "D_CASTLE_19_1_MQ_06", "Let's go.", "I will search a little more."))
			{
				case 1:
					dialog.UnHideNPC("D_CASTLE_19_1_MQ_07_NPC");
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
			await dialog.Msg("D_CASTLE_19_1_MQ_06_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

