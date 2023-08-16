//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (1)
//--- Description -----------------------------------------------------------
// Quest to Move to the area marked on Stonemason Pipoti's map.
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

[QuestScript(1054)]
public class Quest1054Script : QuestScript
{
	protected override void Load()
	{
		SetId(1054);
		SetName("Treasure Map of the Stonemason's Family (1)");
		SetDescription("Move to the area marked on Stonemason Pipoti's map");
		SetTrack("SProgress", "ESuccess", "ROKAS30_PIPOTI02_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI01"));
		AddPrerequisite(new LevelPrerequisite(76));

		AddObjective("collect0", "Collect 1 Key", new CollectItemObjective("ROKAS30_PIPOTI02_ITEM", 1));
		AddDrop("ROKAS30_PIPOTI02_ITEM", 10f, "boss_yonazolem_Q2");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI02_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI02_TREASUREBOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("ROKAS30_PIPOTI02_ITEM", 1))
			{
				character.Inventory.RemoveItem("ROKAS30_PIPOTI02_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				// Func/SCR_ROKAS30_PIPOTI02_TREASUREBOX_OPEN;
				await Task.Delay(2000);
				dialog.HideNPC("ROKAS30_PIPOTI02_TREASUREBOX");
				await dialog.Msg("FadeOutIN/2000");
				dialog.AddonMessage("NOTICE_Dm_Clear", "The treasure chest disappeared!{nl}Right-click on the treasure map and look for the next location!");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

