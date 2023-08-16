//--- Melia Script -----------------------------------------------------------
// Playing with Fire! (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Domas.
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

[QuestScript(20247)]
public class Quest20247Script : QuestScript
{
	protected override void Load()
	{
		SetId(20247);
		SetName("Playing with Fire! (2)");
		SetDescription("Talk to Believer Domas");

		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ02"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_BELIEVER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN19_MQ03_select01", "THORN19_MQ03", "I'll collect the sap", "I don't think it will burn"))
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
			if (character.Inventory.HasItem("THORN19_MQ03_OIL", 8))
			{
				character.Inventory.RemoveItem("THORN19_MQ03_OIL", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("THORN19_MQ03_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN19_MQ04");
	}
}

