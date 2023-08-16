//--- Melia Script -----------------------------------------------------------
// Not as Intended (3)
//--- Description -----------------------------------------------------------
// Quest to Obtain information about Chupacabras from the Supply Officer.
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

[QuestScript(1036)]
public class Quest1036Script : QuestScript
{
	protected override void Load()
	{
		SetId(1036);
		SetName("Not as Intended (3)");
		SetDescription("Obtain information about Chupacabras from the Supply Officer");

		AddPrerequisite(new CompletedPrerequisite("ACT2_DISS1_2_BOSS"));
		AddPrerequisite(new LevelPrerequisite(7));

		AddObjective("kill0", "Kill 7 Large Gray Chupacabra(s)", new KillObjective(400964, 7));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_EAST_RECLAIM6_dlg1", "SIAUL_EAST_RECLAIM6", "I'll defeat the Large Gray Chupacabra", "Cancel"))
			{
				case 1:
					await dialog.Msg("SIAUL_EAST_RECLAIM6_dlg2");
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
			await dialog.Msg("SIAUL_EAST_RECLAIM6_dlg3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_EAST_RECLAIM7");
	}
}

