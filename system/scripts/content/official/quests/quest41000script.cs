//--- Melia Script -----------------------------------------------------------
// Look for the pieces of the pillar
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(41000)]
public class Quest41000Script : QuestScript
{
	protected override void Load()
	{
		SetId(41000);
		SetName("Look for the pieces of the pillar");
		SetDescription("Look at the pillar");

		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA06", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await Task.Delay(2000);
			dialog.AddonMessage("NOTICE_Dm_Clear", "Finally, it seems I would be able to read the letters!");
			await dialog.Msg("EffectLocalNPC/ROKAS_36_1_PILLA06/F_ground139_light_orange/1/BOT");
			await Task.Delay(1000);
			await dialog.Msg("ROKAS_36_1_SQ_060_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

