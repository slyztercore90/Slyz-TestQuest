//--- Melia Script -----------------------------------------------------------
// Retrieve Unidentified Records
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Rugile.
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

[QuestScript(60280)]
public class Quest60280Script : QuestScript
{
	protected override void Load()
	{
		SetId(60280);
		SetName("Retrieve Unidentified Records");
		SetDescription("Talk to Kupole Rugile");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_1"), new CompletedPrerequisite("FANTASYLIB481_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(335));

		AddObjective("collect0", "Collect 15 Unidentified Record(s)", new CollectItemObjective("FANTASYLIB481_SQ_2_ITEM", 15));
		AddDrop("FANTASYLIB481_SQ_2_ITEM", 10f, 58867, 58866, 58864, 58865);

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("FLIBRARY481_RUGILE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY481_RUGILE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB481_SQ_2_1", "FANTASYLIB481_SQ_2", "I will defeat it", "You don't need to do it"))
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
			if (character.Inventory.HasItem("FANTASYLIB481_SQ_2_ITEM", 15))
			{
				character.Inventory.RemoveItem("FANTASYLIB481_SQ_2_ITEM", 15);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FANTASYLIB481_SQ_2_3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

