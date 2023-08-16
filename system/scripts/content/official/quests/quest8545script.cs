//--- Melia Script -----------------------------------------------------------
// Foreseen Crisis (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(8545)]
public class Quest8545Script : QuestScript
{
	protected override void Load()
	{
		SetId(8545);
		SetName("Foreseen Crisis (3)");
		SetDescription("Talk to the Paladin Master");
		SetTrack("SProgress", "ESuccess", "GELE573_MQ_09_AFTER", "track");

		AddPrerequisite(new CompletedPrerequisite("GELE573_MQ_09"));
		AddPrerequisite(new LevelPrerequisite(32));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 3584));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("GELE573_MQ_09_03");
			dialog.UnHideNPC("GELE574_ALLGES");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

