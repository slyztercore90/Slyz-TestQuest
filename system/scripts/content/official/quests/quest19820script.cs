//--- Melia Script -----------------------------------------------------------
// Suffocating Goddess Statue
//--- Description -----------------------------------------------------------
// Quest to Pray in front of the Vakarine Statue.
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

[QuestScript(19820)]
public class Quest19820Script : QuestScript
{
	protected override void Load()
	{
		SetId(19820);
		SetName("Suffocating Goddess Statue");
		SetDescription("Pray in front of the Vakarine Statue");
		SetTrack("SProgress", "ESuccess", "PILGRIM51_SQ_7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(129));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("WARP_F_PILGRIMROAD_51", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

