//--- Melia Script -----------------------------------------------------------
// Sculptor Hilda's Data (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Hilda.
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

[QuestScript(20163)]
public class Quest20163Script : QuestScript
{
	protected override void Load()
	{
		SetId(20163);
		SetName("Sculptor Hilda's Data (3)");
		SetDescription("Talk to Sculptor Hilda");
		SetTrack("SProgress", "ESuccess", "ROKAS25_SQ_08_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS25_SQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ROKAS25_HILDA3", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_HILDA3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS25_SQ_08_select_01", "ROKAS25_SQ_08", "I will protect you", "Let's stop now"))
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
			await dialog.Msg("ROKAS25_SQ_08_succ_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

