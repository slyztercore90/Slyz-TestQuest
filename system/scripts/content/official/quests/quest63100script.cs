//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (1)
//--- Description -----------------------------------------------------------
// Quest to Enter the Moroth Embassy.
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

[QuestScript(63100)]
public class Quest63100Script : QuestScript
{
	protected override void Load()
	{
		SetId(63100);
		SetName("Revelator of Moroth (1)");
		SetDescription("Enter the Moroth Embassy");

		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("EP14_3LINE_TUTO_MQ_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP14_3LINE_TUTO_MQ_1_3");
			dialog.HideNPC("EP14_TUTO_SKIP_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Scroll", "Enter the Moroth Embassy in Kingdom");
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_1_1");
	}
}

