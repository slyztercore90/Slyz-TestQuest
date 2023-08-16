//--- Melia Script -----------------------------------------------------------
// Ready to Return Home
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Lindt.
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

[QuestScript(8041)]
public class Quest8041Script : QuestScript
{
	protected override void Load()
	{
		SetId(8041);
		SetName("Ready to Return Home");
		SetDescription("Talk to Mercenary Lindt");

		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q03"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 8 Wendigo(s) or Dumaro(s) or Wendigo Archer(s) or Wendigo Magician(s)", new KillObjective(8, 41446, 57038, 57621, 57619));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_LINT", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_LINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS26_SUB_Q05_01", "ROKAS26_SUB_Q05", "Defeat monsters for Lindt", "Take a rest before you go"))
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
			await dialog.Msg("ROKAS26_SUB_Q05_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

