//--- Melia Script -----------------------------------------------------------
// Another Owl
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Chief Sculpture.
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

[QuestScript(30058)]
public class Quest30058Script : QuestScript
{
	protected override void Load()
	{
		SetId(30058);
		SetName("Another Owl");
		SetDescription("Talk to the Owl Chief Sculpture");
		SetTrack("SProgress", "ESuccess", "KATYN_10_MQ_10_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_09"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_10_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_10_MQ_10_select", "KATYN_10_MQ_10"))
			{
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

