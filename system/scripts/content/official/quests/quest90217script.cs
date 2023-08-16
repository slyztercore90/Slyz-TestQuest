//--- Melia Script -----------------------------------------------------------
// The Goddess' Reply
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90217)]
public class Quest90217Script : QuestScript
{
	protected override void Load()
	{
		SetId(90217);
		SetName("The Goddess' Reply");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_60"));
		AddPrerequisite(new LevelPrerequisite(335));

		AddDialogHook("CORAL_44_3_OLDMAN4", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_3_SQ_70_ST", "CORAL_44_3_SQ_70"))
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
			await dialog.Msg("CORAL_44_3_SQ_70_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

