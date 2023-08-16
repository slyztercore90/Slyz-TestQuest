//--- Melia Script -----------------------------------------------------------
// The Result of the Test Purification
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Ellie.
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

[QuestScript(70002)]
public class Quest70002Script : QuestScript
{
	protected override void Load()
	{
		SetId(70002);
		SetName("The Result of the Test Purification");
		SetDescription("Talk to Druid Ellie");
		SetTrack("SProgress", "ESuccess", "FARM49_1_MQ03_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("FARM49_1_MQ02"));
		AddPrerequisite(new LevelPrerequisite(149));

		AddDialogHook("FARM491_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_1_MQ_03_1", "FARM49_1_MQ03", "Tell her that everything will be alright", "Leave since you completed all the tasks"))
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
			await dialog.Msg("FARM49_1_MQ_03_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

