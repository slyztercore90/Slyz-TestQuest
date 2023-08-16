//--- Melia Script -----------------------------------------------------------
// Sword for the People and Shield [Highlander Advancement](4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(8704)]
public class Quest8704Script : QuestScript
{
	protected override void Load()
	{
		SetId(8704);
		SetName("Sword for the People and Shield [Highlander Advancement](4)");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new CompletedPrerequisite("JOB_HIGHLANDER4_3"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HIGHLANDER4_4_01", "JOB_HIGHLANDER4_4", "I'll return to the Highlander Master", "I'll be back after a while"))
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
			await dialog.Msg("JOB_HIGHLANDER4_4_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

