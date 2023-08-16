//--- Melia Script -----------------------------------------------------------
// The Silent Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(8308)]
public class Quest8308Script : QuestScript
{
	protected override void Load()
	{
		SetId(8308);
		SetName("The Silent Forest (2)");
		SetDescription("Talk to the Weak Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_OWL_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_02_01", "KATYN18_MQ_02"))
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
			await dialog.Msg("KATYN18_MQ_02_03");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've passed the box of the spirits to the owl sculpture.");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_03");
	}
}

