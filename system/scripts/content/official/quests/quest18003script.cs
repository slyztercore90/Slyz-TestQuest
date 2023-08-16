//--- Melia Script -----------------------------------------------------------
// Drugys Courtyard's Binding Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Check the binding magic circle in Drugys Courtyard..
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

[QuestScript(18003)]
public class Quest18003Script : QuestScript
{
	protected override void Load()
	{
		SetId(18003);
		SetName("Drugys Courtyard's Binding Magic Circle");
		SetDescription("Check the binding magic circle in Drugys Courtyard.");
		SetTrack("SProgress", "ESuccess", "HUEVILLAGE_58_4_MQ03_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ01"));
		AddPrerequisite(new LevelPrerequisite(55));

		AddObjective("kill0", "Kill 1 Mothstem", new KillObjective(47320, 1));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ03_NPC01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

