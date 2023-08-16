//--- Melia Script -----------------------------------------------------------
// Treasure Hunting (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Manderson.
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

[QuestScript(80227)]
public class Quest80227Script : QuestScript
{
	protected override void Load()
	{
		SetId(80227);
		SetName("Treasure Hunting (2)");
		SetDescription("Talk to Guard Manderson");
		SetTrack("SProgress", "ESuccess", "FLASH_29_1_SQ_100_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_090"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH29_1_SQ_090", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH29_1_SQ_090", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH29_1_SQ_100_select01", "FLASH_29_1_SQ_100", "I'll check it out", "I am too lazy to do it"))
			{
				case 1:
					await dialog.Msg("FLASH29_1_SQ_100_agree01");
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("FLASH29_1_SQ_100_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

