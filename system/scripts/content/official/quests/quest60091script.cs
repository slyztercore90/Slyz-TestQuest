//--- Melia Script -----------------------------------------------------------
// The Burnt Whereabouts (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Agent Moren.
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

[QuestScript(60091)]
public class Quest60091Script : QuestScript
{
	protected override void Load()
	{
		SetId(60091);
		SetName("The Burnt Whereabouts (2)");
		SetDescription("Talk with Agent Moren");

		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(5000, 5000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_MOREN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_MOREN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU15RE_MQ_03_01", "SIAU15RE_MQ_03", "I'll try to find them", "I will think about it little more"))
			{
				case 1:
					dialog.UnHideNPC("SIAU15RE_MQ_03_NPC");
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

