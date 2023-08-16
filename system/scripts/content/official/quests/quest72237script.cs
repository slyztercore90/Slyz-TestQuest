//--- Melia Script -----------------------------------------------------------
// From a Mistake to a Threat
//--- Description -----------------------------------------------------------
// Quest to Talk with the Shadowmancer Master.
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

[QuestScript(72237)]
public class Quest72237Script : QuestScript
{
	protected override void Load()
	{
		SetId(72237);
		SetName("From a Mistake to a Threat");
		SetDescription("Talk with the Shadowmancer Master");

		AddPrerequisite(new LevelPrerequisite(400));

		AddDialogHook("JOB_SHADOWMANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SHADOWMANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SHADOW_RAID_QUEST_DLG01", "SHADOW_RAID_QUEST", "Alright", "I can't do it."))
			{
				case 1:
					await dialog.Msg("SHADOW_RAID_QUEST_DLG02");
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
			await dialog.Msg("SHADOW_RAID_QUEST_DLG03");
			dialog.UnHideNPC("PILGRIMROAD_RAID_LEGEND_PORTAL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

