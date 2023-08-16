//--- Melia Script -----------------------------------------------------------
// Interview - Druid Master
//--- Description -----------------------------------------------------------
// Quest to Talk to the Druid Master.
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

[QuestScript(90166)]
public class Quest90166Script : QuestScript
{
	protected override void Load()
	{
		SetId(90166);
		SetName("Interview - Druid Master");
		SetDescription("Talk to the Druid Master");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_MASTER_ENCY_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LOWLV_MASTER_ENCY_SQ_20_ST", "LOWLV_MASTER_ENCY_SQ_20", "I came here to deliver the request from the Sage Master", "Oh, it's nothing"))
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

		return HookResult.Continue;
	}
}

