//--- Melia Script -----------------------------------------------------------
// Mission over Mission
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Roy.
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

[QuestScript(8249)]
public class Quest8249Script : QuestScript
{
	protected override void Load()
	{
		SetId(8249);
		SetName("Mission over Mission");
		SetDescription("Talk to Soldier Roy");

		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_00"));
		AddPrerequisite(new LevelPrerequisite(114));

		AddObjective("collect0", "Collect 1 Puragi's Hook", new CollectItemObjective("KATYN14_MQ_08_ITEM", 1));
		AddDrop("KATYN14_MQ_08_ITEM", 2f, "puragi_blue");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_ROY", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_ROY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN14_MQ_08_01", "KATYN14_MQ_08", "I'll help collect the hooks", "Let's wait until everything is collected"))
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
			if (character.Inventory.HasItem("KATYN14_MQ_08_ITEM", 1))
			{
				character.Inventory.RemoveItem("KATYN14_MQ_08_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("KATYN14_MQ_08_03");
				await dialog.Msg("EffectLocalNPC/KATYN14_ROY/F_pc_warp_circle/1/BOT");
				await Task.Delay(500);
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("KATYN14_ROY");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

