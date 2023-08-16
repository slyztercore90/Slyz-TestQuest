//--- Melia Script -----------------------------------------------------------
// Blast
//--- Description -----------------------------------------------------------
// Quest to Escape from the place.
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

[QuestScript(92027)]
public class Quest92027Script : QuestScript
{
	protected override void Load()
	{
		SetId(92027);
		SetName("Blast");
		SetDescription("Escape from the place");
		SetTrack("SSuccess", "ESuccess", "EP13_F_SIAULIAI_5_MQ01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_08"));
		AddPrerequisite(new LevelPrerequisite(458));

		AddReward(new ItemReward("expCard18", 22));
		AddReward(new ItemReward("Vis", 28396));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_5_MQ_01_SCRL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_5_MQ_01_SCRL", "BeforeEnd", BeforeEnd);
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_5_MQ_02");
	}
}

