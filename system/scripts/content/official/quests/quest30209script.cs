//--- Melia Script -----------------------------------------------------------
// Pass the Tree Vines(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Veed.
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

[QuestScript(30209)]
public class Quest30209Script : QuestScript
{
	protected override void Load()
	{
		SetId(30209);
		SetName("Pass the Tree Vines(1)");
		SetDescription("Talk to Researcher Veed");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_4"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_34_3_SQ_5_select", "ORCHARD_34_3_SQ_5", "Ask how you can craft the Neutralizer", "Simply wait here"))
			{
				case 1:
					await dialog.Msg("ORCHARD_34_3_SQ_5_agree");
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

