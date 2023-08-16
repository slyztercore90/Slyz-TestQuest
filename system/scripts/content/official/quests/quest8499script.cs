//--- Melia Script -----------------------------------------------------------
// Lunatic Wizard (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8499)]
public class Quest8499Script : QuestScript
{
	protected override void Load()
	{
		SetId(8499);
		SetName("Lunatic Wizard (4)");
		SetDescription("Talk to Grita");
		SetTrack("SProgress", "ESuccess", "FTOWER43_MQ_06_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("FTOWER43_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(119));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_G_AI", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("FTOWER43_MQ_06_03");
			dialog.UnHideNPC("FTOWER44_GRITA_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

