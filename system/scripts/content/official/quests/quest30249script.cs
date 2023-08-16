//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (7)
//--- Description -----------------------------------------------------------
// Quest to Check the Tertiary Core Protection Device.
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

[QuestScript(30249)]
public class Quest30249Script : QuestScript
{
	protected override void Load()
	{
		SetId(30249);
		SetName("Operation Outer Wall Core Retrieval (7)");
		SetDescription("Check the Tertiary Core Protection Device");

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(285));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_7", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_OBJ_7", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EffectLocalNPC/CASTLE_20_1_OBJ_7/F_burstup007_blue/1.0/BOT");
			dialog.HideNPC("CASTLE_20_1_OBJ_7");
			dialog.HideNPC("CASTLE_20_1_BARRIER_2");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Disarmed the Tertiary Core Protection Device.{nl}Time to get to the restricted area.");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

