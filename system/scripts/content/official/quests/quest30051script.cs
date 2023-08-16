//--- Melia Script -----------------------------------------------------------
// Owl Sculpture in Danger
//--- Description -----------------------------------------------------------
// Quest to Follow the light bead to Bonewide Cliff.
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

[QuestScript(30051)]
public class Quest30051Script : QuestScript
{
	protected override void Load()
	{
		SetId(30051);
		SetName("Owl Sculpture in Danger");
		SetDescription("Follow the light bead to Bonewide Cliff");
		SetTrack("SProgress", "ESuccess", "KATYN_10_MQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Moa", new KillObjective(58012, 1));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Exclaimation", "The light bead disappeared over the slope!{nl}Turn around and go up Bonewide Cliff.", 5);
	}
}

