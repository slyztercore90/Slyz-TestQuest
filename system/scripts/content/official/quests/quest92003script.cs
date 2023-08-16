//--- Melia Script -----------------------------------------------------------
// Price of Good Deed (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Descend Arcade Power Generator with Mulia.
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

[QuestScript(92003)]
public class Quest92003Script : QuestScript
{
	protected override void Load()
	{
		SetId(92003);
		SetName("Price of Good Deed (1)");
		SetDescription("Check the Descend Arcade Power Generator with Mulia");
		SetTrack("SPossible", "ESuccess", "EP12_2_D_DCAPITAL_108_MQ03_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ03"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ04_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ05");
	}
}

