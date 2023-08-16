//--- Melia Script -----------------------------------------------------------
// Sword for the People and Shield [Highlander Advancement](2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Peltasta Master.
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

[QuestScript(8702)]
public class Quest8702Script : QuestScript
{
	protected override void Load()
	{
		SetId(8702);
		SetName("Sword for the People and Shield [Highlander Advancement](2)");
		SetDescription("Talk to the Peltasta Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_HIGHLANDER4_1"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HIGHLANDER4_2_01", "JOB_HIGHLANDER4_2", "I'll help Knight Commander Uska", "Decline"))
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
			await dialog.Msg("JOB_HIGHLANDER4_2_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_HIGHLANDER4_3");
	}
}

