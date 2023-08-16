//--- Melia Script -----------------------------------------------------------
// For Total Freedom (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(80096)]
public class Quest80096Script : QuestScript
{
	protected override void Load()
	{
		SetId(80096);
		SetName("For Total Freedom (2)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(232));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 163));
		AddReward(new ItemReward("Vis", 66816));

		AddDialogHook("ABBEY_35_4_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_MONK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY_35_4_SQ_8_start", "ABBEY_35_4_SQ_8", "I have a task which I want to ask help from you", "I'll get going now"))
			{
				case 1:
					// Func/ABBEY_35_4_SQ_8_NPC;
					await dialog.Msg("ABBEY_35_4_SQ_8_agree");
					dialog.HideNPC("ABBEY_35_4_MONK");
					dialog.UnHideNPC("ABBEY_35_3_VILLAGE_C");
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
			await dialog.Msg("ABBEY_35_4_SQ_8_succ");
			// Func/ABBEY_35_4_SQ_8_COMP;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

