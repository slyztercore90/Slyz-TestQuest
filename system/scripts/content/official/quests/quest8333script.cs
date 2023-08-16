//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (5)
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

[QuestScript(8333)]
public class Quest8333Script : QuestScript
{
	protected override void Load()
	{
		SetId(8333);
		SetName("Sculptor's Trial (5)");
		SetDescription("Talk to the Test Instructor Owl");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_27_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_26"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(57123, 1));

		AddDialogHook("KATYN18_TESTER_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MQ_27_TRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_27_01", "KATYN18_MQ_27", "Moving to the test site", "Cancel"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/KATYN18_TESTER_03/mon_foot_smoke_3/2.5");
					dialog.HideNPC("KATYN18_TESTER_03");
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
			await dialog.Msg("KATYN18_MQ_27_03");
			dialog.HideNPC("KATYN18_MQ_27_TRACK");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

