//--- Melia Script -----------------------------------------------------------
// Research Archives in Magija Slove (1)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Area Where Old Research Papers May Be Stored.
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

[QuestScript(50405)]
public class Quest50405Script : QuestScript
{
	protected override void Load()
	{
		SetId(50405);
		SetName("Research Archives in Magija Slove (1)");
		SetDescription("Investigate the Area Where Old Research Papers May Be Stored");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(387));

		AddDialogHook("NICO813_SUBQ_SEAL4", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_SEAL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BalloonText/NICO813_SUBQ043_TXT1/7");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

