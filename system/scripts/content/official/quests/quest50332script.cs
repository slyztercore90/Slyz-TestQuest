//--- Melia Script -----------------------------------------------------------
// Creating Distractions (5)
//--- Description -----------------------------------------------------------
// Quest to Go find a place to hide.
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

[QuestScript(50332)]
public class Quest50332Script : QuestScript
{
	protected override void Load()
	{
		SetId(50332);
		SetName("Creating Distractions (5)");
		SetDescription("Go find a place to hide");
		SetTrack("SProgress", "ESuccess", "WTREES22_2_SQ7_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ6"));
		AddPrerequisite(new LevelPrerequisite(348));

		AddObjective("kill0", "Kill 1 Mummyghast", new KillObjective(103048, 1));

		AddReward(new ExpReward(131897408, 131897408));
		AddReward(new ItemReward("Vis", 16704));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("WTREES22_2_SUBQ6_IN", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WTREES22_2_SQ7_START1", "WTREES22_2_SQ7", "Hide.", "The situation seems fine so far."))
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WTREES22_2_SQ8");
	}
}

