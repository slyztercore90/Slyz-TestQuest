//--- Melia Script -----------------------------------------------------------
// Of Father, by Father (2)
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(70044)]
public class Quest70044Script : QuestScript
{
	protected override void Load()
	{
		SetId(70044);
		SetName("Of Father, by Father (2)");
		SetTrack("SProgress", "ESuccess", "FARM49_3_MQ05_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("FARM49_3_MQ04"));
		AddPrerequisite(new LevelPrerequisite(155));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_03", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("FARM49_3_MQ_05_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

