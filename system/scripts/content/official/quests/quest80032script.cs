//--- Melia Script -----------------------------------------------------------
// The Missing Girl (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Leja.
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

[QuestScript(80032)]
public class Quest80032Script : QuestScript
{
	protected override void Load()
	{
		SetId(80032);
		SetName("The Missing Girl (2)");
		SetDescription("Talk to Druid Leja");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 15360));

		AddDialogHook("ORCHARD342_LEJA", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD342_LEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_342_MQ_04_start", "ORCHARD_342_MQ_04", "I'll get it", "I don't think that'll be necessary"))
			{
				case 1:
					dialog.UnHideNPC("ORCHARD342_SLEEP");
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

