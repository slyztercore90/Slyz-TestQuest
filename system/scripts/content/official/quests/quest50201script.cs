//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (9)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
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

[QuestScript(50201)]
public class Quest50201Script : QuestScript
{
	protected override void Load()
	{
		SetId(50201);
		SetName("The Goddess' Flower (9)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ8"));
		AddPrerequisite(new LevelPrerequisite(307));

		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN43_1_SQ9_START1", "BRACKEN43_1_SQ9", "Did you find the whereabouts of Goddess, then?", "Just go"))
			{
				case 1:
					await dialog.Msg("BRACKEN43_1_SQ9_AGREE1");
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
			await dialog.Msg("BRACKEN43_1_SQ9_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

