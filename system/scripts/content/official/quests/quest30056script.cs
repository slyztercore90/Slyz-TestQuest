//--- Melia Script -----------------------------------------------------------
// Gather the Strength of the Owl (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Chief Sculpture.
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

[QuestScript(30056)]
public class Quest30056Script : QuestScript
{
	protected override void Load()
	{
		SetId(30056);
		SetName("Gather the Strength of the Owl (1)");
		SetDescription("Talk to the Owl Chief Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_10_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_10_MQ_08_select", "KATYN_10_MQ_08", "Lend me your power", "I don't think it's necessary"))
			{
				case 1:
					await dialog.Msg("KATYN_10_MQ_08_agree");
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
		character.Quests.Start("KATYN_10_MQ_09");
	}
}

