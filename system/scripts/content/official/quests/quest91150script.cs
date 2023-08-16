//--- Melia Script -----------------------------------------------------------
// Magic Control (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91150)]
public class Quest91150Script : QuestScript
{
	protected override void Load()
	{
		SetId(91150);
		SetName("Magic Control (4)");
		SetDescription("Talk to General Ramin");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE2_MQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(475));

		AddObjective("kill0", "Kill 6 Blickferret Scout(s) or Grasme Crow(s)", new KillObjective(6, 59750, 59745));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_2_LAMIN2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_DCASTLE2_MANA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE2_MQ_7_DLG1", "EP14_2_DCASTLE2_MQ_7", "Okay.", "Injuries should be treated first."))
			{
				case 1:
					dialog.HideNPC("EP14_2_2_LAMIN2");
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
		character.Quests.Start("EP14_2_DCASTLE2_MQ_8");
	}
}

