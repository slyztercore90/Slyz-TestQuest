//--- Melia Script -----------------------------------------------------------
// Unfortunate Demon [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Submaster.
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

[QuestScript(1118)]
public class Quest1118Script : QuestScript
{
	protected override void Load()
	{
		SetId(1118);
		SetName("Unfortunate Demon [Psychokino Advancement]");
		SetDescription("Talk to the Psychokino Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_PSYCHOKINESIST3_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("collect0", "Collect 1 Minotaur's Essence", new CollectItemObjective("JOB_PSYCHOKINESIST3_1_ITEM1", 1));
		AddObjective("collect1", "Collect 1 Chapparition's Essence", new CollectItemObjective("JOB_PSYCHOKINESIST3_1_ITEM2", 1));
		AddDrop("JOB_PSYCHOKINESIST3_1_ITEM1", 10f, "boss_Minotaurs_J1");
		AddDrop("JOB_PSYCHOKINESIST3_1_ITEM2", 10f, "boss_Chapparition_J1");

		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PSYCHOKINESIST3_1_select1", "JOB_PSYCHOKINESIST3_1", "What should I help you with?", "Cancel"))
			{
				case 1:
					await dialog.Msg("JOB_PSYCHOKINESIST3_1_agree1");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			if (character.Inventory.HasItem("JOB_PSYCHOKINESIST3_1_ITEM1", 1) && character.Inventory.HasItem("JOB_PSYCHOKINESIST3_1_ITEM2", 1))
			{
				character.Inventory.RemoveItem("JOB_PSYCHOKINESIST3_1_ITEM1", 1);
				character.Inventory.RemoveItem("JOB_PSYCHOKINESIST3_1_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_PSYCHOKINESIST3_1_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

