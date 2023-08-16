//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (4)
//--- Description -----------------------------------------------------------
// Quest to Inspect the tombstone.
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

[QuestScript(40620)]
public class Quest40620Script : QuestScript
{
	protected override void Load()
	{
		SetId(40620);
		SetName("The Second Epitaph (4)");
		SetDescription("Inspect the tombstone");

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_032"));
		AddPrerequisite(new LevelPrerequisite(172));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeEnd", BeforeEnd);
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
			dialog.HideNPC("REMAINS37_2_MT02_BROKEN");
			dialog.UnHideNPC("REMAINS37_2_MT02");
			await dialog.Msg("FadeOutIN/2500");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've successfully restored the tombstone!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_2_SQ_041");
	}
}

