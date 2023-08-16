//--- Melia Script -----------------------------------------------------------
// Will Not Forget
//--- Description -----------------------------------------------------------
// Quest to Check Zanas' Echo.
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

[QuestScript(30204)]
public class Quest30204Script : QuestScript
{
	protected override void Load()
	{
		SetId(30204);
		SetName("Will Not Forget");
		SetDescription("Check Zanas' Echo");

		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_11"));
		AddPrerequisite(new LevelPrerequisite(272));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_SQ_OBJ_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_SQ_OBJ_2", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EffectLocalNPC/PRISON_82_SQ_OBJ_2/F_light089_green/0.3/BOT");
			// Func/SCR_PRISON_82_SQ_2_SUCC;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

