//--- Melia Script -----------------------------------------------------------
// Hungry Faith (1)
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

[QuestScript(80090)]
public class Quest80090Script : QuestScript
{
	protected override void Load()
	{
		SetId(80090);
		SetName("Hungry Faith (1)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(232));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_MONK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY_35_4_SQ_2_start", "ABBEY_35_4_SQ_2", "I'm not a member of the Order of the Tree of Truth", "Leave it for now"))
			{
				case 1:
					await dialog.Msg("ABBEY_35_4_SQ_2_agree");
					await dialog.Msg("BalloonText/ABBEY_35_4_SQ_2_STUN/8");
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
			if (character.Inventory.HasItem("ABBEY_35_4_SQ_2_FOOD", 1))
			{
				character.Inventory.RemoveItem("ABBEY_35_4_SQ_2_FOOD", 1);
				character.Quests.Complete(this.QuestId);
				await Task.Delay(1000);
				await dialog.Msg("ABBEY_35_4_SQ_2_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

