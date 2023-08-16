//--- Melia Script -----------------------------------------------------------
// Wrong Salvation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sad Owl Sculpture.
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

[QuestScript(8209)]
public class Quest8209Script : QuestScript
{
	protected override void Load()
	{
		SetId(8209);
		SetName("Wrong Salvation (1)");
		SetDescription("Talk to Sad Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_09"));
		AddPrerequisite(new LevelPrerequisite(109));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN72_MQ_10_01", "KATYN72_MQ_10", "I'll go to Amolallul Hill", "I can only help so much"))
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
			await dialog.Msg("KATYN72_MQ_10_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

