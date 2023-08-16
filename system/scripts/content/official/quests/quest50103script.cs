//--- Melia Script -----------------------------------------------------------
// Where Did Everybody Go? (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tess.
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

[QuestScript(50103)]
public class Quest50103Script : QuestScript
{
	protected override void Load()
	{
		SetId(50103);
		SetName("Where Did Everybody Go? (5)");
		SetDescription("Talk to Tess");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ040"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("BRACKEN632_TOWN_PEAPLE_1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_ROZE03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN_63_2_MQ050_startnpc01", "BRACKEN_63_2_MQ050", "Exactly what is happening in the Croa Village?", "I'll ask later"))
			{
				case 1:
					await dialog.Msg("BRACKEN_63_2_MQ050_startnpc02");
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
		character.Quests.Start("BRACKEN_63_2_MQ060");
	}
}

