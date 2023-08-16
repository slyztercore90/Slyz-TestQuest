//--- Melia Script -----------------------------------------------------------
// Castle Wall Soldier's Unfinished Business (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Soul of Castle Wall Soldier.
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

[QuestScript(30267)]
public class Quest30267Script : QuestScript
{
	protected override void Load()
	{
		SetId(30267);
		SetName("Castle Wall Soldier's Unfinished Business (1)");
		SetDescription("Talk with the Soul of Castle Wall Soldier");

		AddPrerequisite(new LevelPrerequisite(300));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_18_RE_SQ_3_select", "KATYN_18_RE_SQ_3", "I am listening.", "You worry too much."))
			{
				case 1:
					await dialog.Msg("KATYN_18_RE_SQ_3_agree");
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
			if (character.Inventory.HasItem("KATYN_18_RE_SQ_3_ITEM", 8))
			{
				character.Inventory.RemoveItem("KATYN_18_RE_SQ_3_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("KATYN_18_RE_SQ_3_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

