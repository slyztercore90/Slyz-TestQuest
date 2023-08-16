//--- Melia Script -----------------------------------------------------------
// Carlyle's Test (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80013)]
public class Quest80013Script : QuestScript
{
	protected override void Load()
	{
		SetId(80013);
		SetName("Carlyle's Test (1)");
		SetDescription("Talk to Carlyle's Spirit");
		SetTrack("SProgress", "ESuccess", "CATACOMB_33_2_SQ_06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Sanctum Object", new KillObjective(152008, 1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_33_2_SQ_06_start", "CATACOMB_33_2_SQ_06", "I am in search of the Order of the Tree of Truth's conspiracy", "Ignore"))
			{
				case 1:
					await dialog.Msg("CATACOMB_33_2_SQ_06_agree");
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

		return HookResult.Continue;
	}
}

