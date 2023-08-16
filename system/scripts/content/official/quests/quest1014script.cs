//--- Melia Script -----------------------------------------------------------
// Talk to the Search Scout
//--- Description -----------------------------------------------------------
// Quest to Find the Search Scout in the marked area.
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

[QuestScript(1014)]
public class Quest1014Script : QuestScript
{
	protected override void Load()
	{
		SetId(1014);
		SetName("Talk to the Search Scout");
		SetDescription("Find the Search Scout in the marked area");
		SetTrack("SProgress", "ESuccess", "SIAUL_WEST_MEET_NAGLIS_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_DRASIUS2"));
		AddPrerequisite(new LevelPrerequisite(2));

		AddObjective("kill0", "Kill 1 Large Kepa", new KillObjective(400002, 1));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("Vis", 26));

		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_WEST_MEET_NAGLIS_dlg1", "SIAUL_WEST_MEET_NAGLIS", "There is an order to assemble", "Nothing. Never mind"))
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
			await dialog.Msg("SIAUL_WEST_MEET_NAGLIS_dlg3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TUTO_SKILL_RUN");
	}
}

