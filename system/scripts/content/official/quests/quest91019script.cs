//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(11)
//--- Description -----------------------------------------------------------
// Quest to Talk to Crusader Master.
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

[QuestScript(91019)]
public class Quest91019Script : QuestScript
{
	protected override void Load()
	{
		SetId(91019);
		SetName("White Witch and the Crusader(11)");
		SetDescription("Talk to Crusader Master");

		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_11"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGDA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG40", "F_TABLELAND_28_2_RAID_12", "I will pass it.", "I can't help you."))
			{
				case 1:
					await dialog.Msg("F_TABLELAND_28_2_RAID_DLG41");
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
			if (character.Inventory.HasItem("F_TABLELAND_28_2_RAID_12_ITEM", 1))
			{
				character.Inventory.RemoveItem("F_TABLELAND_28_2_RAID_12_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG42");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_TABLELAND_28_2_RAID_13");
	}
}

