//--- Melia Script -----------------------------------------------------------
// Good News
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(50261)]
public class Quest50261Script : QuestScript
{
	protected override void Load()
	{
		SetId(50261);
		SetName("Good News");
		SetDescription("Talk to Rose");

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ050"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("ABBEY643_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY64_3_HQ1_start1", "ABBAY64_3_HQ1", "I'll deliver the news.", "I have other issues to tend to."))
			{
				case 1:
					await dialog.Msg("ABBAY64_3_HQ1_agree1");
					await dialog.Msg("BalloonText/ABBAY64_3_HQ1_ROZE/5");
					await dialog.Msg("FadeOutIN/1000");
					await dialog.Msg("ABBAY64_3_HQ1_agree2");
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

		return HookResult.Continue;
	}
}

