//--- Melia Script -----------------------------------------------------------
// Their purpose is
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Lada about the next goal.
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

[QuestScript(91038)]
public class Quest91038Script : QuestScript
{
	protected override void Load()
	{
		SetId(91038);
		SetName("Their purpose is");
		SetDescription("Talk to Goddess Lada about the next goal");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_1_MQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddObjective("collect0", "Collect 1 Crystal Piece of Liepsna Firebug", new CollectItemObjective("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1));
		AddDrop("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 10f, "boss_liepsna_firebug");

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_3", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_06_DLG1", "EP13_F_SIAULIAI_1_MQ_06", "I will investigate Malkos Felled Area ", "My hands are tied at the moment."))
			{
				case 1:
					// Func/SCR_EP13_F_SIAULIAI_1_MQ_LADA_3_HIDE;
					dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_LADA_1");
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
			if (character.Inventory.HasItem("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1))
			{
				character.Inventory.RemoveItem("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP13_F_SIAULIAI_1_MQ_06_DLG2");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
				// Func/SCR_NEXTQUEST_LEVEL_CHECK/EP13_F_SIAULIAI_2_MQ_01;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

