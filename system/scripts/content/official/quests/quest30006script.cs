//--- Melia Script -----------------------------------------------------------
// Preparations for the Dangerous Search (2)
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

[QuestScript(30006)]
public class Quest30006Script : QuestScript
{
	protected override void Load()
	{
		SetId(30006);
		SetName("Preparations for the Dangerous Search (2)");
		SetDescription("Talk with Disciple Hones");
		SetTrack("SProgress", "ESuccess", "CATACOMB_38_2_SQ_06_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_05"));
		AddPrerequisite(new LevelPrerequisite(188));

		AddObjective("collect0", "Collect 1 Soul Crystal", new CollectItemObjective("CATACOMB_04_SQ_03_ITEM", 1));
		AddDrop("CATACOMB_04_SQ_03_ITEM", 10f, "boss_ShadowGaoler_Q2");

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("CATACOMB_04_SQ_MEMO_ITEM", 1));
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
			switch (await dialog.Select("CATACOMB_38_2_SQ_06_start", "CATACOMB_38_2_SQ_06", "What should I do?", "Give up since there's nothing to do"))
			{
				case 1:
					await dialog.Msg("CATACOMB_38_2_SQ_06_agree");
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
			if (character.Inventory.HasItem("CATACOMB_04_SQ_03_ITEM", 1))
			{
				character.Inventory.RemoveItem("CATACOMB_04_SQ_03_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CATACOMB_38_2_SQ_06_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

