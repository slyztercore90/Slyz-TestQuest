//--- Melia Script -----------------------------------------------------------
// Talk to Knight Titas (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Battle Commander.
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

[QuestScript(1013)]
public class Quest1013Script : QuestScript
{
	protected override void Load()
	{
		SetId(1013);
		SetName("Talk to Knight Titas (3)");
		SetDescription("Talk to the Battle Commander");

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_HAMING_LEAF"));
		AddPrerequisite(new LevelPrerequisite(5));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("Vis", 65));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));

		AddDialogHook("SIAUL_WEST_SOL3", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_CAMP_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_WEST_KNIGHT_dlg2", "SIAUL_WEST_KNIGHT", "Alright", "Cancel"))
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
			await dialog.Msg("SIAUL_WEST_KNIGHT_dlg1");
			dialog.ShowHelp("TUTO_RECOVERY");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

