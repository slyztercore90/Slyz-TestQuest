//--- Melia Script -----------------------------------------------------------
// Pull out the Metal Plate
//--- Description -----------------------------------------------------------
// Quest to Talk to Alruida.
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

[QuestScript(40740)]
public class Quest40740Script : QuestScript
{
	protected override void Load()
	{
		SetId(40740);
		SetName("Pull out the Metal Plate");
		SetDescription("Talk to Alruida");
		SetTrack("SProgress", "ESuccess", "REMAINS37_3_SQ_080_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_070"));
		AddPrerequisite(new LevelPrerequisite(176));

		AddObjective("kill0", "Kill 1 Ground Vines", new KillObjective(152038, 1));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS37_3_SQ_080_ST", "REMAINS37_3_SQ_080", "Tell him that you would bring it", "The reason that you could find the Metal Plate easily", "Decline"))
			{
				case 1:
					await dialog.Msg("REMAINS37_3_SQ_080_AC");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("REMAINS37_3_SQ_080_ADD");
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
			await dialog.Msg("REMAINS37_3_SQ_080_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

