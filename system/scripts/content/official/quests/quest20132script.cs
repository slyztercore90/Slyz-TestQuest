//--- Melia Script -----------------------------------------------------------
// Saltistter's Raid
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout.
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

[QuestScript(20132)]
public class Quest20132Script : QuestScript
{
	protected override void Load()
	{
		SetId(20132);
		SetName("Saltistter's Raid");
		SetDescription("Talk to the Scout");
		SetTrack("SProgress", "ESuccess", "KATYN7_MOVE_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(106));

		AddObjective("kill0", "Kill 1 Saltistter", new KillObjective(41207, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("KATYN7_KEYNPC_5", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN7_KEYNPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN7_MOVE_select01", "KATYN7_MOVE", "Alright, I'll help you", "Run away quickly"))
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
			await dialog.Msg("KATYN7_MOVE_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

