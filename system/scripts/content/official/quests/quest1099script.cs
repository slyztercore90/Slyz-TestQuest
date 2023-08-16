//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 4 [Ranger Advancement] (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1099)]
public class Quest1099Script : QuestScript
{
	protected override void Load()
	{
		SetId(1099);
		SetName("Dream Book of the Bow 4 [Ranger Advancement] (5)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_RANGER2_4"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EffectLocalNPC/MASTER_RANGER/archer_buff_skl_Recuperate_circle/1.5/BOT");
			await dialog.Msg("JOB_RANGER2_5_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

