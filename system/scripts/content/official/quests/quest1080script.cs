//--- Melia Script -----------------------------------------------------------
// Guilty Conscience [Sapper Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Find the Stolen Goods.
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

[QuestScript(1080)]
public class Quest1080Script : QuestScript
{
	protected override void Load()
	{
		SetId(1080);
		SetName("Guilty Conscience [Sapper Advancement] (2)");
		SetDescription("Find the Stolen Goods");

		AddPrerequisite(new CompletedPrerequisite("JOB_SAPPER2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("AKALABETH", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("JOB_SAPPER2_2_succ1");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Collect a donation and deliver it to the Cleric Master!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Clear", "Give the Sappers Master's item to people of Klaipeda!");
	}
}

