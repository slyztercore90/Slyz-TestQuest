//--- Melia Script -----------------------------------------------------------
// Chasing Lord Delmore (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Yane.
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

[QuestScript(70440)]
public class Quest70440Script : QuestScript
{
	protected override void Load()
	{
		SetId(70440);
		SetName("Chasing Lord Delmore (1)");
		SetDescription("Talk to Revelator Yane");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CASTLE653_MQ_01_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE653_MQ_01_start", "CASTLE65_3_MQ01", "Let's follow after", "Tell her to wait a bit"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE65_3_MQ02");
	}
}

