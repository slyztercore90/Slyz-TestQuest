//--- Melia Script -----------------------------------------------------------
// Cursed Statues (4)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Cursed Statues with the Purification Sphere.
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

[QuestScript(50179)]
public class Quest50179Script : QuestScript
{
	protected override void Load()
	{
		SetId(50179);
		SetName("Cursed Statues (4)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_73_SQ3"));
		AddPrerequisite(new LevelPrerequisite(250));

		AddObjective("kill0", "Kill 11 White Wendigo Searcher(s) or Blue Tini Archer(s) or Blue Hohen Gulak(s)", new KillObjective(11, 57873, 57906, 57977));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeEnd", BeforeEnd);
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "You destroyed the cursed statue!");
			// Func/TABLE73_SUBQ1_COMPLETE;
			await dialog.Msg("EffectLocalNPC/TABLE73_SUB_ARTIFACT2/F_explosion098_dark_blue/1/BOT");
			await dialog.Msg("NPCAin/TABLE73_SUB_ARTIFACT2/DEAD/0");
			await dialog.Msg("EffectLocalNPC/TABLELAND73_SUBQ4_DEVICE/F_explosion098_dark_blue/1/BOT");
			await dialog.Msg("NPCAin/TABLELAND73_SUBQ4_DEVICE/DEAD/0");
			dialog.HideNPC("TABLE73_SUB_ARTIFACT2");
			dialog.HideNPC("TABLELAND73_SUBQ4_DEVICE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

