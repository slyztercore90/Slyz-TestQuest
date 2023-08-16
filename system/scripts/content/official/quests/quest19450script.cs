//--- Melia Script -----------------------------------------------------------
// Insatiable Hunger (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Liliya.
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

[QuestScript(19450)]
public class Quest19450Script : QuestScript
{
	protected override void Load()
	{
		SetId(19450);
		SetName("Insatiable Hunger (2)");
		SetDescription("Talk to Pilgrim Liliya");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_010"));
		AddPrerequisite(new LevelPrerequisite(121));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM46_SQ_020_ST", "PILGRIM46_SQ_020", "Ask her if there's anything she particularly wants", "You better leave without being involved in the matter"))
			{
				case 1:
					await dialog.Msg("PILGRIM46_SQ_020_AC");
					dialog.UnHideNPC("PILGRIM46_REED");
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
			await dialog.Msg("PILGRIM46_SQ_020_COMP");
			await Task.Delay(2000);
			await dialog.Msg("EffectLocalNPC/PILGRIM46_NPC01/F_burstup005_fire/1/BOT");
			dialog.HideNPC("PILGRIM46_REED");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

