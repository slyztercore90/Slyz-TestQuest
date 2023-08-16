//--- Melia Script -----------------------------------------------------------
// Blessings of the Goddesses [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Submaster.
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

[QuestScript(70305)]
public class Quest70305Script : QuestScript
{
	protected override void Load()
	{
		SetId(70305);
		SetName("Blessings of the Goddesses [Krivis Advancement]");
		SetDescription("Talk to the Krivis Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_KRIVIS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_KRIVIS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_KRIVIS2_1_1", "JOB_2_KRIVIS2", "I am fine", "That doesn't look like a test"))
			{
				case 1:
					await dialog.Msg("JOB_2_KRIVIS2_1_2");
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

