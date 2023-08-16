//--- Melia Script -----------------------------------------------------------
// Two Types of Orders
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Dominic.
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

[QuestScript(4372)]
public class Quest4372Script : QuestScript
{
	protected override void Load()
	{
		SetId(4372);
		SetName("Two Types of Orders");
		SetDescription("Talk to Soldier Dominic");
		SetTrack("SProgress", "ESuccess", "THORN22_Q_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(120));

		AddObjective("kill0", "Kill 5 Wood Goblin(s) or Meleech(s)", new KillObjective(5, 41290, 41285));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3000));

		AddDialogHook("THORN22_DOMINIC", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_DOMINIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN22_Q_1_select1", "THORN22_Q_1", "I'll help scout around", "Decline"))
			{
				case 1:
					await dialog.Msg("THORN22_Q_1_select1_a");
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
			await dialog.Msg("THORN22_Q_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

