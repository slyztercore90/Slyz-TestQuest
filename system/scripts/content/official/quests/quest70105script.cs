//--- Melia Script -----------------------------------------------------------
// The First Step of Cooperation
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Tracker Capt. Mintz.
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

[QuestScript(70105)]
public class Quest70105Script : QuestScript
{
	protected override void Load()
	{
		SetId(70105);
		SetName("The First Step of Cooperation");
		SetDescription("Talk to Hunter Tracker Capt. Mintz");

		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ05"));
		AddPrerequisite(new LevelPrerequisite(173));

		AddDialogHook("THORN392_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_2_MQ_06_1", "THORN39_2_MQ06", "Go see Potos to give him the trap", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("THORN39_2_MQ_06_2");
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
			await dialog.Msg("THORN39_2_MQ_06_5");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

