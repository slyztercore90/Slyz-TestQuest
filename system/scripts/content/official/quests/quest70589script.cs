//--- Melia Script -----------------------------------------------------------
// Restraining the Criminal
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70589)]
public class Quest70589Script : QuestScript
{
	protected override void Load()
	{
		SetId(70589);
		SetName("Restraining the Criminal");
		SetDescription("Talk to Monk Stella");
		SetTrack("SSuccess", "ESuccess", "PILGRIM41_5_SQ10_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ09"));
		AddPrerequisite(new LevelPrerequisite(271));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_10", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_10", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM415_SQ_10_start", "PILGRIM41_5_SQ10", "Say that you will retrieve the Fragments", "Say that you do not think the Fragments will be in usable shape"))
			{
				case 1:
					await dialog.Msg("PILGRIM415_SQ_10_agree");
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
			if (character.Inventory.HasItem("PILGRIM41_5_SQ10_ITEM", 6))
			{
				character.Inventory.RemoveItem("PILGRIM41_5_SQ10_ITEM", 6);
				character.Quests.Complete(this.QuestId);
				dialog.UnHideNPC("PILGRIM415_SQ_10_4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

