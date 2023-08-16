//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (4)
//--- Description -----------------------------------------------------------
// Quest to Chest the material storage chest.
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

[QuestScript(30223)]
public class Quest30223Script : QuestScript
{
	protected override void Load()
	{
		SetId(30223);
		SetName("Investigate Inner Wall District 8 (4)");
		SetDescription("Chest the material storage chest");

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_4"));
		AddPrerequisite(new LevelPrerequisite(279));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("CASTLE_20_3_SQ_6_ITEM", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_OBJ_8", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_OBJ_8", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("CASTLE_20_3_SQ_5_ITEM_3", 1))
			{
				character.Inventory.RemoveItem("CASTLE_20_3_SQ_5_ITEM_3", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/CASTLE_20_3_OBJ_8/F_burstup007_smoke1/0.6/BOT");
				dialog.HideNPC("CASTLE_20_3_OBJ_8");
				dialog.UnHideNPC("CASTLE_20_3_OBJ_8_AFTER");
				dialog.AddonMessage("NOTICE_Dm_Scroll", "There is Magic Circle Maintenance Department near the magical eye.{nl}Check the content.");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

