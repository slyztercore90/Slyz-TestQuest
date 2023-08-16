//--- Melia Script -----------------------------------------------------------
// Victims' Request
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Gintas' Spirit.
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

[QuestScript(50274)]
public class Quest50274Script : QuestScript
{
	protected override void Load()
	{
		SetId(50274);
		SetName("Victims' Request");
		SetDescription("Talk to Believer Gintas' Spirit");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_09"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("CATACOMB332_HQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("INQUISITOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB33_2_HQ1_start1", "CATACOMB33_2_HQ1", "I'll find Margiris' book.", "Just go"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

