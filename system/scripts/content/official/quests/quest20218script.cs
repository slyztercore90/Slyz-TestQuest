//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (5)
//--- Description -----------------------------------------------------------
// Quest to Find Agailla Flurry's gravestones .
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

[QuestScript(20218)]
public class Quest20218Script : QuestScript
{
	protected override void Load()
	{
		SetId(20218);
		SetName("Flurry's Epitaphs (5)");
		SetDescription("Find Agailla Flurry's gravestones ");

		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ05"));
		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_MQ_MONUMENT5", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_MQ_MONUMENT5", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAINS39_MQ06_succ01");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've read a tombstone of Agailla Flurry{nl}Read the other tombstones to obtain the artifacts of Flurry");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

