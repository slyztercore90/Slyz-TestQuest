//--- Melia Script -----------------------------------------------------------
// Preparations for the Dangerous Search (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Disciple Hones.
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

[QuestScript(30005)]
public class Quest30005Script : QuestScript
{
	protected override void Load()
	{
		SetId(30005);
		SetName("Preparations for the Dangerous Search (1)");
		SetDescription("Talk with Disciple Hones");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(188));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("CATACOMB_38_2_SQ_06_ITEM", 1));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 5828));

		AddDialogHook("CATACOMB_38_2_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_38_2_SQ_05_start", "CATACOMB_38_2_SQ_05", "Ask him how you could help him", "Ask him to look for another person"))
			{
				case 1:
					await dialog.Msg("CATACOMB_38_2_SQ_05_agree");
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
			if (character.Inventory.HasItem("CATACOMB_38_2_SQ_05_ITEM", 10))
			{
				character.Inventory.RemoveItem("CATACOMB_38_2_SQ_05_ITEM", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CATACOMB_38_2_SQ_05_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_2_SQ_06");
	}
}

