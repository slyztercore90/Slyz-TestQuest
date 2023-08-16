//--- Melia Script -----------------------------------------------------------
// Curse, Begone! (3)
//--- Description -----------------------------------------------------------
// Quest to Install the Sculpture and Defeat the Demons.
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

[QuestScript(72229)]
public class Quest72229Script : QuestScript
{
	protected override void Load()
	{
		SetId(72229);
		SetName("Curse, Begone! (3)");
		SetDescription("Install the Sculpture and Defeat the Demons");
		SetTrack("SProgress", "ESuccess", "CASTLE94_MAIN07_BEFORE_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE94_MAIN06"));
		AddPrerequisite(new LevelPrerequisite(395));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20882));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE94_NPC_MAIN02", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("CASTLE94_MAIN07_01");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

