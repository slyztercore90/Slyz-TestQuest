//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Sculpture of Forecasts.
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

[QuestScript(8330)]
public class Quest8330Script : QuestScript
{
	protected override void Load()
	{
		SetId(8330);
		SetName("Sculptor's Trial (2)");
		SetDescription("Talk to the Owl Sculpture of Forecasts");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_24_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_23"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Evil Spirit(s) or Red Banshee(s)", new KillObjective(6, 400103, 400102));

		AddDialogHook("KATYN18_MAIN_OWL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_TESTER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_24_01", "KATYN18_MQ_24", "Accept", "Cancel"))
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
			await dialog.Msg("KATYN18_MQ_24_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_25");
	}
}

