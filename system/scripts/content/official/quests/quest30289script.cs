//--- Melia Script -----------------------------------------------------------
// Demon Treaty (4)
//--- Description -----------------------------------------------------------
// Quest to Retrieve the Demon Treaty in Tamsus Ikeitimas.
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

[QuestScript(30289)]
public class Quest30289Script : QuestScript
{
	protected override void Load()
	{
		SetId(30289);
		SetName("Demon Treaty (4)");
		SetDescription("Retrieve the Demon Treaty in Tamsus Ikeitimas");
		SetTrack("SProgress", "ESuccess", "WTREES_21_1_SQ_6_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(325));

		AddObjective("kill0", "Kill 1 Cerberus", new KillObjective(107021, 1));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("WTREES_21_1_SQ_6_ITEM", 1));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_OBJ_4", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_1_OBJ_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage("NOTICE_Dm_Clear", "The Demon Treaty is now in your hands.{nl}Return to the site of the treaty seal.");
			await dialog.Msg("EffectLocalNPC/WTREES_21_1_OBJ_4/F_pc_making_finish_red/2.0/MID");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

