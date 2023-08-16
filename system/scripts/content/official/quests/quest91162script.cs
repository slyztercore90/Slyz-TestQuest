//--- Melia Script -----------------------------------------------------------
// To the Turbulent Core
//--- Description -----------------------------------------------------------
// Quest to Clear [Goddess Raid: Turbulent Core].
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

[QuestScript(91162)]
public class Quest91162Script : QuestScript
{
	protected override void Load()
	{
		SetId(91162);
		SetName("To the Turbulent Core");
		SetDescription("Clear [Goddess Raid: Turbulent Core]");

		AddPrerequisite(new CompletedPrerequisite("RAID_CASTLE_EP14_2_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddDialogHook("RAID_CASTLE_EP14_2_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_CASTLE_EP14_2_SOLD", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			await dialog.Msg("RAID_CASTLE_EP14_2_MQ_2_DLG1");
			await dialog.Msg("FadeOutIN/3000");
			dialog.HideNPC("RAID_CASTLE_EP14_2_SOLD");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

