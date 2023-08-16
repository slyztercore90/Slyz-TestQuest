//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (1)
//--- Description -----------------------------------------------------------
// Quest to Examine the Mirtinas.
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

[QuestScript(92028)]
public class Quest92028Script : QuestScript
{
	protected override void Load()
	{
		SetId(92028);
		SetName("Extinct Mirtinas (1)");
		SetDescription("Examine the Mirtinas");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_5_MQ_02_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_01_RE"));
		AddPrerequisite(new LevelPrerequisite(458));

		AddReward(new ItemReward("expCard18", 22));
		AddReward(new ItemReward("Vis", 28396));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_5_WAVE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_5_RAGANA", "BeforeEnd", BeforeEnd);
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
			dialog.UnHideNPC("EP13_F_SIAULIAI_5_RAGANA");
			await dialog.Msg("EP13_F_SIAULIAI_5_MQ_02_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

