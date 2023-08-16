//--- Melia Script -----------------------------------------------------------
// Material Search [Dievdirbys Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Tesla.
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

[QuestScript(8746)]
public class Quest8746Script : QuestScript
{
	protected override void Load()
	{
		SetId(8746);
		SetName("Material Search [Dievdirbys Advancement]");
		SetDescription("Talk to Sculptor Tesla");
		SetTrack("SProgress", "ESuccess", "JOB_DIEVDIRBYS5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Dense Hardwood", new CollectItemObjective("JOB_DIEVDIRBYS5_1_ITEM", 1));
		AddDrop("JOB_DIEVDIRBYS5_1_ITEM", 10f, "boss_woodspirit_green");

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_DIEVDIRBYS5_1_01", "JOB_DIEVDIRBYS5_1", "I'll get the materials for you", "Ignore"))
			{
				case 1:
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
			if (character.Inventory.HasItem("JOB_DIEVDIRBYS5_1_ITEM", 1))
			{
				character.Inventory.RemoveItem("JOB_DIEVDIRBYS5_1_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_DIEVDIRBYS5_1_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

