//--- Melia Script -----------------------------------------------------------
// Quality Certificate [Appraiser Advancement](2) 
//--- Description -----------------------------------------------------------
// Quest to Talk to the Appraiser Master.
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

[QuestScript(50299)]
public class Quest50299Script : QuestScript
{
	protected override void Load()
	{
		SetId(50299);
		SetName("Quality Certificate [Appraiser Advancement](2) ");
		SetDescription("Talk to the Appraiser Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_APPRAISER5_1"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("FEDIMIAN_APPRAISER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FEDIMIAN_APPRAISER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_APPRAISER5_2_start1", "JOB_APPRAISER5_2", "Deliver the Quality Certificate", "Okay, I will return with the items."))
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
			await dialog.Msg("JOB_APPRAISER5_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

