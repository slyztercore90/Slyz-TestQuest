//--- Melia Script -----------------------------------------------------------
// [Tutorial] Combat with boss monster
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(63113)]
public class Quest63113Script : QuestScript
{
	protected override void Load()
	{
		SetId(63113);
		SetName("[Tutorial] Combat with boss monster");
		SetDescription("Talk to Owynia Dilben");
		SetTrack("SProgress", "ESuccess", "EP14_3LINE_TUTO_MQ_9_1_TRACk", 2000);

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_9"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(57185, 1));

		AddDialogHook("EP14_OWYNIA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_OWYNIA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_3LINE_TUTO_MQ_9_1_1", "EP14_3LINE_TUTO_MQ_9_1", "I'll find out", "It's too dangerous to do it alone"))
			{
				case 1:
					dialog.HideNPC("EP14_3LINE_TUTO_MQ_9_1_GATE");
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
			await dialog.Msg("EP14_3LINE_TUTO_MQ_9_1_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_10");
	}
}

