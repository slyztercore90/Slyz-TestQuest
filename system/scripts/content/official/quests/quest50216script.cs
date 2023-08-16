//--- Melia Script -----------------------------------------------------------
// Marks of a legend(6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jenonhas.
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

[QuestScript(50216)]
public class Quest50216Script : QuestScript
{
	protected override void Load()
	{
		SetId(50216);
		SetName("Marks of a legend(6)");
		SetDescription("Talk to Jenonhas");
		SetTrack("SProgress", "ESuccess", "BRACKEN43_3_SQ6_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ5"));
		AddPrerequisite(new LevelPrerequisite(313));

		AddDialogHook("BRACKEN433_SUBQ5_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN43_3_SQ6_START1", "BRACKEN43_3_SQ6", "Follow Jenonhas", "Leave him alone"))
			{
				case 1:
					dialog.HideNPC("BRACKEN433_SUBQ5_NPC1");
					await dialog.Msg("FadeOutIN/1000");
					dialog.UnHideNPC("BRACKEN433_SUBQ5_NPC2");
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
			await dialog.Msg("BRACKEN43_3_SQ6_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

