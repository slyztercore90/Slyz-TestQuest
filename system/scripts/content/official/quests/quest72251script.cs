//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Laima's Spinning Wheel.
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

[QuestScript(72251)]
public class Quest72251Script : QuestScript
{
	protected override void Load()
	{
		SetId(72251);
		SetName("Laima's Spinning Wheel (3)");
		SetDescription("Talk to Laima's Spinning Wheel");
		SetTrack("SPossible", "ESuccess", "CASTLE102_MQ_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(436));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 25288));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE102_MQ_04_DLG01", "CASTLE102_MQ_04", "I will do it", "Give me some time"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CASTLE102_MQ_04_DLG04");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

