//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60286)]
public class Quest60286Script : QuestScript
{
	protected override void Load()
	{
		SetId(60286);
		SetName("The Vulnerable Fugitive (6)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack("SProgress", "ESuccess", "DCAPITAL105_SQ_6_TRACK", 8000);

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(371));

		AddObjective("kill0", "Kill 6 Bishop Star(s)", new KillObjective(59092, 6));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20628));

		AddDialogHook("DCAPITAL105_GRISIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL105_GRISIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL105_SQ_6_1", "DCAPITAL105_SQ_6", "I'll try to find them", "I need to prepare"))
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
			await dialog.Msg("DCAPITAL105_SQ_6_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

