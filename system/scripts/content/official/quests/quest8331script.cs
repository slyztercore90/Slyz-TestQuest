//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Test Instructor Owl.
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

[QuestScript(8331)]
public class Quest8331Script : QuestScript
{
	protected override void Load()
	{
		SetId(8331);
		SetName("Sculptor's Trial (3)");
		SetDescription("Talk to the Test Instructor Owl");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_25", 2000);

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_24"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Evil Spirit(s)", new KillObjective(400103, 6));

		AddDialogHook("KATYN18_TESTER_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_TESTER_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_25_01", "KATYN18_MQ_25", "Accept", "Cancel"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/KATYN18_TESTER_01/mon_foot_smoke_3/2.5");
					dialog.HideNPC("KATYN18_TESTER_01");
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
			await dialog.Msg("KATYN18_MQ_25_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_26");
	}
}

