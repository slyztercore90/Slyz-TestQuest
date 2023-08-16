//--- Melia Script -----------------------------------------------------------
// Talk to the Scout (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout in the marked area.
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

[QuestScript(1003)]
public class Quest1003Script : QuestScript
{
	protected override void Load()
	{
		SetId(1003);
		SetName("Talk to the Scout (1)");
		SetDescription("Talk to the Scout in the marked area");
		SetTrack("SProgress", "ESuccess", "SIAUL_WEST_DRASIUS1_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_WEST_FOREST"));
		AddPrerequisite(new LevelPrerequisite(1));

		AddObjective("kill0", "Kill 4 Kepa(s)", new KillObjective(400001, 4));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_WEST_DRASIUS1_dlg1", "SIAUL_WEST_DRASIUS1", "I'm just here to tell the troops to assemble", "Quickly run away"))
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
			await dialog.Msg("SIAUL_WEST_DRASIUS1_dlg2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_WEST_DRASIUS2");
	}
}

