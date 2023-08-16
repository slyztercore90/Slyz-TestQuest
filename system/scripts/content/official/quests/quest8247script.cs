//--- Melia Script -----------------------------------------------------------
// Where are the Supply Troops (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Officer.
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

[QuestScript(8247)]
public class Quest8247Script : QuestScript
{
	protected override void Load()
	{
		SetId(8247);
		SetName("Where are the Supply Troops (3)");
		SetDescription("Talk to the Supply Officer");

		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(114));

		AddDialogHook("KATYN14_SUPP", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_LAIMUNAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN14_MQ_06_01", "KATYN14_MQ_06"))
			{
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
			await dialog.Msg("KATYN14_MQ_06_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

