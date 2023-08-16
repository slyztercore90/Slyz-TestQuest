//--- Melia Script -----------------------------------------------------------
// A Difficult Opponent
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Tracker Capt. Mintz.
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

[QuestScript(70127)]
public class Quest70127Script : QuestScript
{
	protected override void Load()
	{
		SetId(70127);
		SetName("A Difficult Opponent");
		SetDescription("Talk to Hunter Tracker Capt. Mintz");

		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ07"));
		AddPrerequisite(new LevelPrerequisite(176));

		AddDialogHook("THORN392_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_1_MQ_08_1", "THORN39_1_MQ08"))
			{
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
			await dialog.Msg("THORN39_1_MQ_08_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

