//--- Melia Script -----------------------------------------------------------
// Effective Painkillers
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Lindt.
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

[QuestScript(8039)]
public class Quest8039Script : QuestScript
{
	protected override void Load()
	{
		SetId(8039);
		SetName("Effective Painkillers");
		SetDescription("Talk to Mercenary Lindt");

		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q02"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_LINT", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_LINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS26_SUB_Q03_01", "ROKAS26_SUB_Q03", "I will get them", "I don't have anything"))
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
			await dialog.Msg("ROKAS26_SUB_Q03_02");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_SUB_Q05");
	}
}

