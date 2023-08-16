//--- Melia Script -----------------------------------------------------------
// Old Story (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8458)]
public class Quest8458Script : QuestScript
{
	protected override void Load()
	{
		SetId(8458);
		SetName("Old Story (7)");
		SetDescription("Talk to Coben");
		SetTrack("SProgress", "ESuccess", "REMAINS40_MQ_07_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("kill0", "Kill 1 Cursed Devilglove", new KillObjective(41385, 1));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("REMAINS40_MQ_07_ITEM", 1));
		AddReward(new ItemReward("misc_liena_top_1", 1));
		AddReward(new ItemReward("Vis", 33384));

		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS40_MQ_07_01", "REMAINS40_MQ_07", "Go and check what's written on the last tombstone.", "Decline"))
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
			await dialog.Msg("REMAINS40_MQ_07_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

