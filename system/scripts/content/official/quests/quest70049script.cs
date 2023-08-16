//--- Melia Script -----------------------------------------------------------
// Shifting Responsibility
//--- Description -----------------------------------------------------------
// Quest to Talk to General Buros.
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

[QuestScript(70049)]
public class Quest70049Script : QuestScript
{
	protected override void Load()
	{
		SetId(70049);
		SetName("Shifting Responsibility");
		SetDescription("Talk to General Buros");
		SetTrack("SProgress", "ESuccess", "FARM49_3_SQ04_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("FARM49_3_SQ03"));
		AddPrerequisite(new LevelPrerequisite(155));

		AddObjective("kill0", "Kill 1 Glass Mole", new KillObjective(41367, 1));

		AddReward(new ExpReward(1279350, 1279350));
		AddReward(new ItemReward("expCard8", 5));
		AddReward(new ItemReward("TreasureboxKey4", 1));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_3_SQ_04_1", "FARM49_3_SQ04", "You feel something strange, but I will be responsible for it", "Reject it since you just did what you were told"))
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
			await dialog.Msg("FARM49_3_SQ_04_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

