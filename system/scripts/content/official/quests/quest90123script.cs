//--- Melia Script -----------------------------------------------------------
// On the Brink of Madness
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Representative Morkus.
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

[QuestScript(90123)]
public class Quest90123Script : QuestScript
{
	protected override void Load()
	{
		SetId(90123);
		SetName("On the Brink of Madness");
		SetDescription("Talk to Refugee Representative Morkus");

		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_20"), new CompletedPrerequisite("MAPLE_25_2_SQ_30"), new CompletedPrerequisite("MAPLE_25_2_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(285));

		AddReward(new ItemReward("MAPLE_25_2_SQ_50_ITEM", 1));

		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE_25_2_SQ_50_ST", "MAPLE_25_2_SQ_50", "I will go and ask.", "That seems difficult"))
			{
				case 1:
					await dialog.Msg("MAPLE_25_2_SQ_50_AG");
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
			dialog.HideNPC("MAPLE_25_2_MORKUS");
			await dialog.Msg("FadeOutIN/3000");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

