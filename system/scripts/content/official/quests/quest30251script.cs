//--- Melia Script -----------------------------------------------------------
// Incident on Triple-Layerd Castle Wall (1)
//--- Description -----------------------------------------------------------
// Quest to Deliver the  Outer Wall Core to Kupole Milda.
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

[QuestScript(30251)]
public class Quest30251Script : QuestScript
{
	protected override void Load()
	{
		SetId(30251);
		SetName("Incident on Triple-Layerd Castle Wall (1)");
		SetDescription("Deliver the  Outer Wall Core to Kupole Milda");

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new ItemPrerequisite("CASTLE_20_1_SQ_8_ITEM", -100), new ItemPrerequisite("CASTLE_20_2_SQ_10_ITEM_2", -100), new ItemPrerequisite("CASTLE_20_1_SQ_2_ITEM", -100));

		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE_20_1_SQ_9_select", "CASTLE_20_1_SQ_9", "I will go to Jore.", "That's quite enough for me."))
			{
				case 1:
					await dialog.Msg("CASTLE_20_1_SQ_9_agree");
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
			await dialog.Msg("CASTLE_20_1_SQ_9_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

