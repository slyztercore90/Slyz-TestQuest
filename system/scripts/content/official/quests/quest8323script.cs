//--- Melia Script -----------------------------------------------------------
// Opening the Barrier (1)
//--- Description -----------------------------------------------------------
// Quest to Conversation with gloomy owl image.
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

[QuestScript(8323)]
public class Quest8323Script : QuestScript
{
	protected override void Load()
	{
		SetId(8323);
		SetName("Opening the Barrier (1)");
		SetDescription("Conversation with gloomy owl image");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_16"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_OWL_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_KEEPER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_17_01", "KATYN18_MQ_17"))
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
			await dialog.Msg("KATYN18_MQ_17_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_18");
	}
}

