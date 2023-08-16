//--- Melia Script -----------------------------------------------------------
// The Burnt Whereabouts (1)
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

[QuestScript(60090)]
public class Quest60090Script : QuestScript
{
	protected override void Load()
	{
		SetId(60090);
		SetName("The Burnt Whereabouts (1)");
		SetDescription("Talk with Agent Moren");

		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new ItemPrerequisite("SIAU15RE_MQ_01_1_ITEM", -100));

		AddReward(new ExpReward(7500, 7500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_MOREN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_MOREN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU15RE_MQ_02_01", "SIAU15RE_MQ_02", "Leave it to me", "I don't think I can do that"))
			{
				case 1:
					dialog.AddonMessage("NOTICE_Dm_Scroll", "Protect Agent Moren from the monsters while he investigates the traces!", 8);
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

