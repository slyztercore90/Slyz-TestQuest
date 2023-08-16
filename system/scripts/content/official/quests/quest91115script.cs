//--- Melia Script -----------------------------------------------------------
// Identity of Grasme
//--- Description -----------------------------------------------------------
// Quest to Destroy Beholder's Black Crystal.
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

[QuestScript(91115)]
public class Quest91115Script : QuestScript
{
	protected override void Load()
	{
		SetId(91115);
		SetName("Identity of Grasme");
		SetDescription("Destroy Beholder's Black Crystal");
		SetTrack("SSuccess", "ESuccess", "EP14_1_FCASTLE4_MQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(466));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29358));

		AddDialogHook("EP14_1_FCASTLE4_MQ_7_BLACKCRYSTAL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("EP14_1_FCASTLE4_MQ_7_BLACKCRYSTAL1");
			dialog.HideNPC("EP14_1_FCASTLE4_MQ_7_FERRET");
			dialog.UnHideNPC("EP14_1_FCASTLE4_MQ_8_HIDDEN");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

