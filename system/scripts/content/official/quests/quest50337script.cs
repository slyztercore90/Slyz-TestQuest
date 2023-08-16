//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50337)]
public class Quest50337Script : QuestScript
{
	protected override void Load()
	{
		SetId(50337);
		SetName("Narvas Temple's Barrier (3)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ2"));
		AddPrerequisite(new LevelPrerequisite(351));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WTREES22_3_SUBQ3_START1", "WTREES22_3_SQ3", "Help Monk Aistis.", "I'll help you shortly after."))
			{
				case 1:
					// Func/WTREES22_3_SUBQ3_START_FUNC1;
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
			await dialog.Msg("WTREES22_3_SQ3_SUCC1");
			dialog.HideNPC("WTREES22_3_SUBQ1_NPC2");
			dialog.UnHideNPC("WTREES22_3_SUBQ1_NPC3");
			await dialog.Msg("FadeOutIN/1000");
			// Func/WTREES22_3_SUBQ3_COMP_FUNC1;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

