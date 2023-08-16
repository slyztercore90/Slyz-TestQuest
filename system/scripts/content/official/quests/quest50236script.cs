//--- Melia Script -----------------------------------------------------------
// Ah Fresh Sample [Necromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Necromancer Master.
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

[QuestScript(50236)]
public class Quest50236Script : QuestScript
{
	protected override void Load()
	{
		SetId(50236);
		SetName("Ah Fresh Sample [Necromancer Advancement]");
		SetDescription("Talk to the Necromancer Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("JOB_NECRO4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_NECRO4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_NECROMANCER7_1_START1", "JOB_NECROMANCER7_1", "I am more than happy to do it.", "Think of another solution"))
			{
				case 1:
					await dialog.Msg("JOB_NECROMANCER7_1_ADD");
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
			await dialog.Msg("JOB_NECROMANCER7_1_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

