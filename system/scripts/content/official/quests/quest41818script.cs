//--- Melia Script -----------------------------------------------------------
// Destroy the Portal
//--- Description -----------------------------------------------------------
// Quest to Talk to the Recovery Squad Adjutant.
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

[QuestScript(41818)]
public class Quest41818Script : QuestScript
{
	protected override void Load()
	{
		SetId(41818);
		SetName("Destroy the Portal");
		SetDescription("Talk to the Recovery Squad Adjutant");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(388));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_27_1_SQ_8_DLG1", "F_3CMLAKE_27_1_SQ_8", "I'll make sure that portal gets destroyed.", "I need some time to rest."))
			{
				case 1:
					dialog.UnHideNPC("F_3CMLAKE_27_1_SQ_8_PNPC");
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
			await dialog.Msg("F_3CMLAKE_27_1_SQ_8_DLG3");
			// Func/FADEFUNC;
			dialog.HideNPC("F_3CMLAKE_27_1_NPC2_3");
			dialog.HideNPC("F_3CMLAKE_27_1_SQ_8_PNPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

