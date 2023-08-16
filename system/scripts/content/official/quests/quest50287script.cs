//--- Melia Script -----------------------------------------------------------
// Angry Bees (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(50287)]
public class Quest50287Script : QuestScript
{
	protected override void Load()
	{
		SetId(50287);
		SetName("Angry Bees (2)");
		SetDescription("Talk with Priest Raeli");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI462_HQ1"));
		AddPrerequisite(new LevelPrerequisite(166));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI462_HQ2_start1", "SIAULIAI462_HQ2", "I'll place the candle down myself.", "I'll do it later"))
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
			await dialog.Msg("SIAULIAI462_HQ1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

