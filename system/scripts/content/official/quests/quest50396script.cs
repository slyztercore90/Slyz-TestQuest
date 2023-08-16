//--- Melia Script -----------------------------------------------------------
// The Closing Dragnet (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50396)]
public class Quest50396Script : QuestScript
{
	protected override void Load()
	{
		SetId(50396);
		SetName("The Closing Dragnet (3)");
		SetDescription("Talk to Auguste Dupin");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_09"));
		AddPrerequisite(new LevelPrerequisite(384));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 25000));

		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("NICOPOLIS812_SQ10_START1", "F_NICOPOLIS_81_2_SQ_10", "Have a look.", "Leave this place"))
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
			// Func/SCR_NIC812_SUBQ10_FUNC;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

