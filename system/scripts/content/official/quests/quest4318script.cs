//--- Melia Script -----------------------------------------------------------
// Historian Kepeck (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Kepeck.
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

[QuestScript(4318)]
public class Quest4318Script : QuestScript
{
	protected override void Load()
	{
		SetId(4318);
		SetName("Historian Kepeck (3)");
		SetDescription("Talk to Historian Kepeck");
		SetTrack("SProgress", "ESuccess", "ROKAS24_KILL3_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_15"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("kill0", "Kill 1 Ginklas", new KillObjective(57062, 1));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Hat_628023", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_KEFEK", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_NEALS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS24_KILL3_select1", "ROKAS24_KILL3", "I'll help even though you don't know what it is", "I didn't come here to help"))
			{
				case 1:
					await dialog.Msg("ROKAS24_KILL3_prog1");
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
			await dialog.Msg("ROKAS24_KILL3_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

