//--- Melia Script -----------------------------------------------------------
// Secure Route to the Gateway of the Great King (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Julian.
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

[QuestScript(4384)]
public class Quest4384Script : QuestScript
{
	protected override void Load()
	{
		SetId(4384);
		SetName("Secure Route to the Gateway of the Great King (2)");
		SetDescription("Talk to Commander Julian");
		SetTrack("SProgress", "ESuccess", "THORN22_Q_13_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_10"));
		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 8 Wood Goblin(s)", new KillObjective(41290, 8));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_JULIAN", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_OROURKE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN22_Q_13_select1", "THORN22_Q_13", "I will apply for it", "I don't have time for that"))
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
			await dialog.Msg("THORN22_Q_13_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

