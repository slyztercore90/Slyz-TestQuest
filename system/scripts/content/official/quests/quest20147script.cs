//--- Melia Script -----------------------------------------------------------
// Ardor for Study (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Friedka.
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

[QuestScript(20147)]
public class Quest20147Script : QuestScript
{
	protected override void Load()
	{
		SetId(20147);
		SetName("Ardor for Study (2)");
		SetDescription("Talk to Archaeologist Friedka");
		SetTrack("SProgress", "ESuccess", "ROKAS28_MQ5_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("ROKAS28_EXPOSURE"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 1 Bebraspion", new KillObjective(57079, 1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_FRIDKA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_FRIDKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS28_MQ5_select1", "ROKAS28_MQ5", "I'll rub a copy", "I can only help so much"))
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
			await dialog.Msg("ROKAS28_MQ5_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

