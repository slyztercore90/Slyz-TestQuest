//--- Melia Script -----------------------------------------------------------
// Astral Tracing (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Talus.
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

[QuestScript(20211)]
public class Quest20211Script : QuestScript
{
	protected override void Load()
	{
		SetId(20211);
		SetName("Astral Tracing (4)");
		SetDescription("Talk to Hunter Talus");

		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ03"));
		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_MQ_MONUMENT4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAIN38_MQ04_select01", "REMAIN38_MQ04", "Good bye. (go to check on the tombstone)", "Stop it here"))
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've examined the fourth tombstone of Lydia Schaffen{nl}Check what is written on the last tombstone");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN38_MQ05");
	}
}

