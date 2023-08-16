//--- Melia Script -----------------------------------------------------------
// Edmundas' Worry (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Submaster.
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

[QuestScript(50140)]
public class Quest50140Script : QuestScript
{
	protected override void Load()
	{
		SetId(50140);
		SetName("Edmundas' Worry (3)");
		SetDescription("Talk to the Wizard Submaster");

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_SQ020"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("JOB_2_WIZARD_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_WIZARD_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY_64_3_SQ030_startnpc01", "ABBAY_64_3_SQ030", "Please tell me how", "I'll be back after I'm ready"))
			{
				case 1:
					await dialog.Msg("ABBAY_64_3_SQ030_startnpc02");
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBAY_64_3_SQ040");
	}
}

