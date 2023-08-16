//--- Melia Script -----------------------------------------------------------
// Destroy the Demons' Device (1)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Demons' Device.
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

[QuestScript(50190)]
public class Quest50190Script : QuestScript
{
	protected override void Load()
	{
		SetId(50190);
		SetName("Destroy the Demons' Device (1)");
		SetDescription("Investigate the Demons' Device");

		AddPrerequisite(new LevelPrerequisite(253));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TABLELAND_74_SQ8");
	}
}

