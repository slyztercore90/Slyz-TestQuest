//--- Melia Script -----------------------------------------------------------
// Dead of the Dead (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40560)]
public class Quest40560Script : QuestScript
{
	protected override void Load()
	{
		SetId(40560);
		SetName("Dead of the Dead (4)");
		SetDescription("Talk to Adrijus");

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_070"));
		AddPrerequisite(new LevelPrerequisite(168));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS37_1_SQ_080_ST", "REMAINS37_1_SQ_080", "I will go to Vseio Cliffs", "I won't help anymore"))
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
			await dialog.Msg("REMAINS37_1_SQ_080_COMP");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

