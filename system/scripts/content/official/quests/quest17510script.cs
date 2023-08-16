//--- Melia Script -----------------------------------------------------------
// Grace of Wealth [Pardoner Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Meet Fedimian Item Merchant.
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

[QuestScript(17510)]
public class Quest17510Script : QuestScript
{
	protected override void Load()
	{
		SetId(17510);
		SetName("Grace of Wealth [Pardoner Advancement] (2)");
		SetDescription("Meet Fedimian Item Merchant");
		SetTrack("SProgress", "ESuccess", "JOB_PARDONER4_2_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("JOB_PARDONER4_3"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("collect0", "Collect 1 Mothstem's Fire Jar", new CollectItemObjective("JOB_PARDONER4_2_ITEM2", 1));
		AddDrop("JOB_PARDONER4_2_ITEM2", 10f, "boss_Mothstem_J1");

		AddDialogHook("FED_TOOL", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PARDONER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PARDONER4_2_ST", "JOB_PARDONER4_2", "I will defeat Mothstem", "I give up"))
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
			if (character.Inventory.HasItem("JOB_PARDONER4_2_ITEM2", 1))
			{
				character.Inventory.RemoveItem("JOB_PARDONER4_2_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_PARDONER4_2_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

