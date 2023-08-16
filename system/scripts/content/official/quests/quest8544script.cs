//--- Melia Script -----------------------------------------------------------
// Foreseen Crisis (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(8544)]
public class Quest8544Script : QuestScript
{
	protected override void Load()
	{
		SetId(8544);
		SetName("Foreseen Crisis (1)");
		SetDescription("Talk to the Paladin Master");

		AddPrerequisite(new CompletedPrerequisite("GELE572_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(32));

		AddReward(new ExpReward(219492, 219492));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("KEY_OF_LEGEND_01", 1));
		AddReward(new ItemReward("Vis", 5760));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE573_MQ_07_01", "GELE573_MQ_07", "I'll ask", "I'm not ready to hear it yet"))
			{
				case 1:
					dialog.UnHideNPC("GELE573_MQ_07_F");
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
			await dialog.Msg("GELE573_MQ_07_03");
			dialog.HideNPC("GELE573_MQ_07_F");
			// Func/GELE573_MQ_07_AI;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

