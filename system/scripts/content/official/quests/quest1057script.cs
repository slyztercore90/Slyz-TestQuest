//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (4)
//--- Description -----------------------------------------------------------
// Quest to Move to the marked area on Stonemason Pipoti's map.
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

[QuestScript(1057)]
public class Quest1057Script : QuestScript
{
	protected override void Load()
	{
		SetId(1057);
		SetName("Treasure Map of the Stonemason's Family (4)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack("SProgress", "ESuccess", "ROKAS30_PIPOTI05_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI04"));
		AddPrerequisite(new LevelPrerequisite(76));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(57416, 1));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI05_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI05_TREASUREBOX", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_ROKAS30_PIPOTI05_TREASUREBOX_OPEN;
			await Task.Delay(1000);
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've failed to find the treasure of the Stonemason family!{nl}Pipoti disappeared, but you will have a chance to meet him again!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

