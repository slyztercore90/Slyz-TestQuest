//--- Melia Script -----------------------------------------------------------
// Alembique Tales(5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Celvica.
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

[QuestScript(60214)]
public class Quest60214Script : QuestScript
{
	protected override void Load()
	{
		SetId(60214);
		SetName("Alembique Tales(5)");
		SetDescription("Talk with Priest Celvica");

		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(320));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_GIGO_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LSCAVE551_SQ_6_1", "LSCAVE551_SQ_6", "I'll try to find them", "It's not a good idea to spread out."))
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
			await dialog.Msg("LSCAVE551_SQ_6_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

