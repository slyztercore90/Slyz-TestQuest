//--- Melia Script -----------------------------------------------------------
// Secure the Area
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Poulter.
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

[QuestScript(4382)]
public class Quest4382Script : QuestScript
{
	protected override void Load()
	{
		SetId(4382);
		SetName("Secure the Area");
		SetDescription("Talk to Soldier Poulter");

		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_10"));
		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 15 Meleech(s) or Ravinelarva(s) or Wood Goblin(s) or Treegool(s)", new KillObjective(15, 41285, 41269, 41290, 41264));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_POULLTER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_POULLTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN22_Q_11_select1", "THORN22_Q_11", "Alright, I'll help you", "Decline"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("THORN22_Q_11_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

