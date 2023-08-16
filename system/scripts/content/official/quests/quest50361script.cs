//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (6)
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

[QuestScript(50361)]
public class Quest50361Script : QuestScript
{
	protected override void Load()
	{
		SetId(50361);
		SetName("Suspiciously Secretive (6)");
		SetDescription("Talk to Agailla Flurry Apparition");
		SetTrack("SProgress", "ESuccess", "ABBEY22_5_SQ7_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ6"));
		AddPrerequisite(new LevelPrerequisite(357));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_5_SUBQ7_START1", "ABBEY22_5_SQ7", "Approach Suspicion Hauberk.", "I'll wait a little bit"))
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ABBEY22_5_SUBQ7_SUCC1");
			await dialog.Msg("EffectLocalNPC/ABBEY22_4_SUBQ11_FLURRY/F_buff_basic028_violet_line/1/BOT");
			dialog.HideNPC("ABBEY225_FLURRY2");
			dialog.UnHideNPC("ABBEY225_FLURRY3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

