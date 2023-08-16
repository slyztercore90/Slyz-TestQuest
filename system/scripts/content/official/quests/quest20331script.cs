//--- Melia Script -----------------------------------------------------------
// Adapting to Circumstances (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20331)]
public class Quest20331Script : QuestScript
{
	protected override void Load()
	{
		SetId(20331);
		SetName("Adapting to Circumstances (4)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ02"));
		AddPrerequisite(new LevelPrerequisite(145));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_MQ_BISHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL56_MQ03", "CHATHEDRAL56_MQ03", "Accept", "Reject"))
			{
				case 1:
					dialog.HideNPC("CHATHEDRAL56_MQ_BISHOP");
					await dialog.Msg("EffectLocalNPC/CHATHEDRAL56_MQ_BISHOP/F_buff_basic025_white_line_2/1/BOT");
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

