//--- Melia Script -----------------------------------------------------------
// Price of Good Deed (2)
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

[QuestScript(92006)]
public class Quest92006Script : QuestScript
{
	protected override void Load()
	{
		SetId(92006);
		SetName("Price of Good Deed (2)");
		SetDescription("Check the Descend Arcade Power Generator with Mulia");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_2_D_DCAPITAL_108_MQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ06"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ07_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ08");
	}
}

