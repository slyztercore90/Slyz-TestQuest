//--- Melia Script -----------------------------------------------------------
// The Final Battle (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72210)]
public class Quest72210Script : QuestScript
{
	protected override void Load()
	{
		SetId(72210);
		SetName("The Final Battle (2)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(386));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20458));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("STARTOWER_92_MQ_20_DLG1", "STARTOWER_92_MQ_20", "Alright", "There's no need for that."))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("STARTOWER_92_MQ_20_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

