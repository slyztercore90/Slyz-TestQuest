//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (3)
//--- Description -----------------------------------------------------------
// Quest to Ask the blacksmith in Klaipeda about adhesives.
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

[QuestScript(40610)]
public class Quest40610Script : QuestScript
{
	protected override void Load()
	{
		SetId(40610);
		SetName("The Second Epitaph (3)");
		SetDescription("Ask the blacksmith in Klaipeda about adhesives");

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_031"));
		AddPrerequisite(new LevelPrerequisite(172));

		AddDialogHook("BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS37_2_SQ_032_ST", "REMAINS37_2_SQ_032", "Tell him that you understand", "Tell him that you will look for other methods"))
			{
				case 1:
					await dialog.Msg("REMAINS37_2_SQ_032_ACC");
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
			dialog.AddonMessage("NOTICE_Dm_Exclaimation", "Make the glue the blacksmith advised to you", 5);
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_2_SQ_040");
	}
}

