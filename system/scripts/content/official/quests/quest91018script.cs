//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(10)
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

[QuestScript(91018)]
public class Quest91018Script : QuestScript
{
	protected override void Load()
	{
		SetId(91018);
		SetName("White Witch and the Crusader(10)");
		SetDescription("Talk to Crusader Master");

		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_10"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ItemReward("expCard17", 1));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG38", "F_TABLELAND_28_2_RAID_11", "Alright", "That's too difficult to do now."))
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
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG39");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_TABLELAND_28_2_RAID_12");
	}
}

