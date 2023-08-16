//--- Melia Script -----------------------------------------------------------
// Proving skills
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher James.
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

[QuestScript(9102)]
public class Quest9102Script : QuestScript
{
	protected override void Load()
	{
		SetId(9102);
		SetName("Proving skills");
		SetDescription("Talk to Watcher James");

		AddPrerequisite(new LevelPrerequisite(27));

		AddObjective("kill0", "Kill 40 Ellomago(s) or Ridimed(s) or Red Meduja(s) or Sakmoli(s)", new KillObjective(40, 41443, 400541, 400244, 400561));

		AddDialogHook("GELE_57_3_HQ01_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("GELE_57_3_HQ01_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE_57_3_HQ_01_select01", "GELE_57_3_HQ_01", "I will accept that bet", "Decline"))
			{
				case 1:
					await dialog.Msg("GELE_57_3_HQ_01_Q");
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
			await dialog.Msg("GELE_57_3_HQ_01_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

