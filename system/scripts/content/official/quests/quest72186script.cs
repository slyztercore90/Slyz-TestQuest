//--- Melia Script -----------------------------------------------------------
// Take Back the Second Control Room
//--- Description -----------------------------------------------------------
// Quest to Move to the Second Control Room.
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

[QuestScript(72186)]
public class Quest72186Script : QuestScript
{
	protected override void Load()
	{
		SetId(72186);
		SetName("Take Back the Second Control Room");
		SetDescription("Move to the Second Control Room");
		SetTrack("SProgress", "ESuccess", "STARTOWER_89_MQ_60_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_50"));
		AddPrerequisite(new LevelPrerequisite(375));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_2ND_DEFENCE_DEVICE", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_STARTOWER_DEFENCE_DEVICE_UNLOCK_EFFECT/0;
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've undone all defense systems on 4F!{nl}Talk to Resistance Supreme Commander Byle.");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("STARTOWER_89_MQ_60_DLG2");
	}
}

