//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60262)]
public class Quest60262Script : QuestScript
{
	protected override void Load()
	{
		SetId(60262);
		SetName("Necessary Mistake (8)");
		SetDescription("Talk to Neringa");
		SetTrack("SProgress", "ESuccess", "FANTASYLIB483_MQ_8_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_7"));
		AddPrerequisite(new LevelPrerequisite(341));

		AddObjective("collect0", "Collect 1 Record: Giltine", new CollectItemObjective("FANTASYLIB483_MQ_8_ITEM", 1));
		AddDrop("FANTASYLIB483_MQ_8_ITEM", 10f, "boss_Templeshooter_Q2");

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_NERINGA_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_NERINGA_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB483_MQ_8_1", "FANTASYLIB483_MQ_8", "I'll provide support.", "I need to prepare"))
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
			if (character.Inventory.HasItem("FANTASYLIB483_MQ_8_ITEM", 1))
			{
				character.Inventory.RemoveItem("FANTASYLIB483_MQ_8_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FANTASYLIB483_MQ_8_3");
				dialog.HideNPC("FLIBRARY483_NERINGA_NPC_3");
				await dialog.Msg("FadeOutIN/1500");
				dialog.UnHideNPC("FLIBRARY484_NERINGA_NPC_1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

