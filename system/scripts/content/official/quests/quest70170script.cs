//--- Melia Script -----------------------------------------------------------
// Lessen the Head Count
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Potos.
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

[QuestScript(70170)]
public class Quest70170Script : QuestScript
{
	protected override void Load()
	{
		SetId(70170);
		SetName("Lessen the Head Count");
		SetDescription("Talk to Senior Monk Potos");

		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ09"));
		AddPrerequisite(new LevelPrerequisite(183));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY39_4_SQ_01_1", "ABBEY39_4_SQ01", "I will help too", "Decline"))
			{
				case 1:
					await dialog.Msg("ABBEY39_4_SQ_01_2");
					dialog.UnHideNPC("ABBEY394_SQ_01_1");
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
			await dialog.Msg("ABBEY39_4_SQ_01_4");
			dialog.HideNPC("ABBEY394_SQ_01_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

