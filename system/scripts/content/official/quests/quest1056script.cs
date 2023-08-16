//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (3)
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

[QuestScript(1056)]
public class Quest1056Script : QuestScript
{
	protected override void Load()
	{
		SetId(1056);
		SetName("Treasure Map of the Stonemason's Family (3)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack("SProgress", "ESuccess", "ROKAS30_PIPOTI04_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI03"));
		AddPrerequisite(new LevelPrerequisite(76));

		AddObjective("kill0", "Kill 5 Hogma Warrior(s) or Hogma Shaman(s)", new KillObjective(5, 41433, 41435));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI04_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI04_TREASUREBOX", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_ROKAS30_PIPOTI04_TREASUREBOX_OPEN;
			await Task.Delay(1000);
			dialog.AddonMessage("NOTICE_Dm_Clear", "The treasure chest was empty!{nl}Right-click on the treasure map and look for the next location!");
			dialog.UnHideNPC("ROKAS30_TREASUREBOX98");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

