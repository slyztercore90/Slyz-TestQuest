//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50229)]
public class Quest50229Script : QuestScript
{
	protected override void Load()
	{
		SetId(50229);
		SetName("Maven's Wishes(9)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ7"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ8_START1", "BRACKEN43_4_SQ8", "Ask how you should help", "I will find it later"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_4_SQ8_AGREE1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("BRACKEN434_SUBQ8_ITEM1", 11))
		{
			character.Inventory.RemoveItem("BRACKEN434_SUBQ8_ITEM1", 11);
			await dialog.Msg("BRACKEN43_4_SQ8_SUCC1");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EffectLocalNPC/BRACKEN434_SUBQ1_NPC4/F_pc_making_finish_white/2/TOP");
			character.Quests.Complete(this.QuestId);
			await Task.Delay(2000);
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BRACKEN43_4_SQ8_SUCC1_1");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BalloonText/BRACKEN434_SUBQ3_DLG/3");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("FadeOutIN/1500");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BRACKEN43_4_SQ8_SUCC2");
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("BRACKEN434_SUBQ1_NPC4");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
			dialog.UnHideNPC("BRACKEN434_SUBQ1_NPC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

