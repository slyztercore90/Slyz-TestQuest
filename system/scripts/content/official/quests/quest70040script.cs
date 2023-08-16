//--- Melia Script -----------------------------------------------------------
// The Farm's Stubborn Owner
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Martinek.
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

[QuestScript(70040)]
public class Quest70040Script : QuestScript
{
	protected override void Load()
	{
		SetId(70040);
		SetName("The Farm's Stubborn Owner");
		SetDescription("Talk to Druid Martinek");

		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ07"));
		AddPrerequisite(new LevelPrerequisite(155));

		AddDialogHook("FARM493_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_3_MQ_01_1", "FARM49_3_MQ01", "I will try persuading him", "Tell him that even a Revelator can't do it"))
			{
				case 1:
					await dialog.Msg("FARM49_3_MQ_01_3");
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
			await dialog.Msg("FARM49_3_MQ_01_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

