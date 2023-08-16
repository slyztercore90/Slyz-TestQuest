//--- Melia Script -----------------------------------------------------------
// Curse, Begone! (2)
//--- Description -----------------------------------------------------------
// Quest to Operate the Switchgear.
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

[QuestScript(72228)]
public class Quest72228Script : QuestScript
{
	protected override void Load()
	{
		SetId(72228);
		SetName("Curse, Begone! (2)");
		SetDescription("Operate the Switchgear");
		SetTrack("SPossible", "ESuccess", "CASTLE94_MAIN06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE94_MAIN05"));
		AddPrerequisite(new LevelPrerequisite(395));

		AddObjective("kill0", "Kill 1 Deranged Vel's Chariot", new KillObjective(59267, 1));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 41764));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE94_NPC_01", "BeforeEnd", BeforeEnd);
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
			dialog.HideNPC("CASTLE94_NPC_03");
			dialog.UnHideNPC("CASTLE94_NPC_05");
			// Func/SCR_CASTLE94_MAIN06_END;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

