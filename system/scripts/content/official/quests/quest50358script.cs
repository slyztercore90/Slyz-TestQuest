//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50358)]
public class Quest50358Script : QuestScript
{
	protected override void Load()
	{
		SetId(50358);
		SetName("Suspiciously Secretive (3)");
		SetDescription("Talk to Agailla Flurry Apparition");
		SetTrack("SProgress", "ESuccess", "ABBEY22_5_SQ4_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ3"));
		AddPrerequisite(new LevelPrerequisite(357));

		AddObjective("collect0", "Collect 1 King Hammer's Blood", new CollectItemObjective("ABBEY22_5_SUBQ5_ITEM1", 1));
		AddDrop("ABBEY22_5_SUBQ5_ITEM1", 10f, "boss_kinghammer_Q1");

		AddReward(new ExpReward(131897408, 131897408));
		AddReward(new ItemReward("ABBEY22_5_SUBQ5_ITEM2", 1));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("ABBEY225_FLURRY1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_5_SUBQ4_START1", "ABBEY22_5_SQ4", "Go and deal with King Hammer.", "I'll wait a little bit"))
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
			if (character.Inventory.HasItem("ABBEY22_5_SUBQ5_ITEM1", 1))
			{
				character.Inventory.RemoveItem("ABBEY22_5_SUBQ5_ITEM1", 1);
				character.Quests.Complete(this.QuestId);
				dialog.AddonMessage("NOTICE_Dm_Clear", "Placed King Hammer's Blood");
				// Func/ABBEY22_5_SUBQ4_COMP;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

