//--- Melia Script -----------------------------------------------------------
// Handling Monsters [Falconer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Falconer Master.
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

[QuestScript(30043)]
public class Quest30043Script : QuestScript
{
	protected override void Load()
	{
		SetId(30043);
		SetName("Handling Monsters [Falconer Advancement]");
		SetDescription("Talk with the Falconer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_FALCONER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FALCONER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_FALCONER_6_1_select", "JOB_FALCONER_6_1", "How can I tame the monster?", "That's absurd"))
			{
				case 1:
					await dialog.Msg("JOB_FALCONER_6_1_agree");
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
			await dialog.Msg("JOB_FALCONER_6_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

