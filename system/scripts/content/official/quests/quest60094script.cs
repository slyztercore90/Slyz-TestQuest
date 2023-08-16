//--- Melia Script -----------------------------------------------------------
// Overworked Agent
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Pierneef.
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

[QuestScript(60094)]
public class Quest60094Script : QuestScript
{
	protected override void Load()
	{
		SetId(60094);
		SetName("Overworked Agent");
		SetDescription("Talk with Chaser Pierneef");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Poisoned Kepa(s)", new KillObjective(400005, 5));
		AddObjective("kill1", "Kill 1 Pokuborn", new KillObjective(58091, 1));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_FERNIFF", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_FERNIFF", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU15RE_SQ_01_01", "SIAU15RE_SQ_01", "Can I help you with anything?", "Get some rest and be careful"))
			{
				case 1:
					await dialog.Msg("SIAU15RE_SQ_01_01_ag");
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

		return HookResult.Continue;
	}
}

