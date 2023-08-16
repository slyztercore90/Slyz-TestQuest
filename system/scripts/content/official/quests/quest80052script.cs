//--- Melia Script -----------------------------------------------------------
// Fading breaths
//--- Description -----------------------------------------------------------
// Quest to Look for Necromancer Adomas carefully.
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

[QuestScript(80052)]
public class Quest80052Script : QuestScript
{
	protected override void Load()
	{
		SetId(80052);
		SetName("Fading breaths");
		SetDescription("Look for Necromancer Adomas carefully");
		SetTrack("SProgress", "ESuccess", "TABLELAND_11_1_SQ_01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(208));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_ADOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_LEMIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_11_1_SQ_01_start", "TABLELAND_11_1_SQ_01", "I will pass it", "You should first get yourself together"))
			{
				case 1:
					await dialog.Msg("BalloonText/TABLELAND_11_1_SQ_01_agree/3");
					dialog.UnHideNPC("TABLELAND_11_1_DARK_WALL");
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
			await dialog.Msg("TABLELAND_11_1_SQ_01_succ");
			dialog.HideNPC("TABLELAND_11_1_ADOMAS");
			dialog.HideNPC("TABLELAND_11_1_ADOMAS_BAG");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

