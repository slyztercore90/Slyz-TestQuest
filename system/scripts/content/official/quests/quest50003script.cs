//--- Melia Script -----------------------------------------------------------
// To Kvailas Forest
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(50003)]
public class Quest50003Script : QuestScript
{
	protected override void Load()
	{
		SetId(50003);
		SetName("To Kvailas Forest");
		SetDescription("Talk to Goddess Saule");
		SetTrack("SSuccess", "ESuccess", "HUEVILLAGE_58_4_MQ09_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ08"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_MQ09_BLACK_MAN", "BeforeEnd", BeforeEnd);
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
}

