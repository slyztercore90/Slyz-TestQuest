//--- Melia Script -----------------------------------------------------------
// Preparation for using the equipment
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70563)]
public class Quest70563Script : QuestScript
{
	protected override void Load()
	{
		SetId(70563);
		SetName("Preparation for using the equipment");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ03"));
		AddPrerequisite(new LevelPrerequisite(268));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM413_SQ_04_start", "PILGRIM41_3_SQ04", "Ask if there is a way to charge the power", "Say that this is as far as you will help"))
			{
				case 1:
					await dialog.Msg("PILGRIM413_SQ_04_agree");
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
			await dialog.Msg("PILGRIM413_SQ_04_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

