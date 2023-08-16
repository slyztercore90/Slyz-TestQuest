//--- Melia Script -----------------------------------------------------------
// Little by Little, a History Book
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Grenus.
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

[QuestScript(60158)]
public class Quest60158Script : QuestScript
{
	protected override void Load()
	{
		SetId(60158);
		SetName("Little by Little, a History Book");
		SetDescription("Talk to Historian Grenus");

		AddPrerequisite(new LevelPrerequisite(58));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS24_RP_2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_RP_2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS24_RP_2_1", "ROKAS24_RP_2", "Alright, I'll help you", "Decline"))
			{
				case 1:
					dialog.UnHideNPC("ROKAS24_RP_2_OBJ");
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
			await dialog.Msg("ROKAS24_RP_2_3");
			dialog.HideNPC("ROKAS24_RP_2_OBJ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

