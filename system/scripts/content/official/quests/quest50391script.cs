//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (5)
//--- Description -----------------------------------------------------------
// Quest to Search the Raktas Intersection.
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

[QuestScript(50391)]
public class Quest50391Script : QuestScript
{
	protected override void Load()
	{
		SetId(50391);
		SetName("The Feline Post Town Case (5)");
		SetDescription("Search the Raktas Intersection");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(384));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 21500));

		AddDialogHook("NICO812_SUB5_NPC1_IN", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC5", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("F_NICOPOLIS_81_2_SQ_06");
	}
}

