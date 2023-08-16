//--- Melia Script -----------------------------------------------------------
// Save the Holy Offering [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Master.
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

[QuestScript(8398)]
public class Quest8398Script : QuestScript
{
	protected override void Load()
	{
		SetId(8398);
		SetName("Save the Holy Offering [Krivis Advancement]");
		SetDescription("Talk to the Krivis Master");
		SetTrack("SProgress", "ESuccess", "JOB_KRIWI1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("kill0", "Kill 8 Vubbe Thief(s)", new KillObjective(11120, 8));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_KRIWI1_OUT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_KRIWI1_01", "JOB_KRIWI1", "I will find the Krivis brother", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_KRIWI1_02");
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
			await dialog.Msg("JOB_KRIWI1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_KRIWI1_1");
	}
}

