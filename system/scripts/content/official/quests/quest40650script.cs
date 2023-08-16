//--- Melia Script -----------------------------------------------------------
// Interpreting the Tombstone's Story
//--- Description -----------------------------------------------------------
// Quest to Meet the Wings of Vaivora in Klaipeda.
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

[QuestScript(40650)]
public class Quest40650Script : QuestScript
{
	protected override void Load()
	{
		SetId(40650);
		SetName("Interpreting the Tombstone's Story");
		SetDescription("Meet the Wings of Vaivora in Klaipeda");

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_020"), new CompletedPrerequisite("REMAINS37_2_SQ_040"), new CompletedPrerequisite("REMAINS37_2_SQ_060"));
		AddPrerequisite(new LevelPrerequisite(172));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("REMAINS37_2_SQ_070_ITEM_1", 1));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("JOURNEY_SHOP", "BeforeStart", BeforeStart);
		AddDialogHook("JOURNEY_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("REMAINS37_2_SQ_070_COMP");
			await dialog.Msg("PCAin/TALK/1");
			await Task.Delay(1500);
			await dialog.Msg("REMAINS37_2_SQ_070_COMP_2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Clear", "You are unsure of what was written on the tombstone.{nl}Go to the Wings of Vaivora in Klaipeda and ask.");
	}
}

