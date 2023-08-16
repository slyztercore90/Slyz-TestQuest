//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (2)
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

[QuestScript(1055)]
public class Quest1055Script : QuestScript
{
	protected override void Load()
	{
		SetId(1055);
		SetName("Treasure Map of the Stonemason's Family (2)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack("SProgress", "ESuccess", "ROKAS30_PIPOTI03_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI02"));
		AddPrerequisite(new LevelPrerequisite(76));

		AddObjective("kill0", "Kill 6 Hogma Scout(s)", new KillObjective(47309, 6));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI03_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI03_TREASUREBOX", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_ROKAS30_PIPOTI03_TREASUREBOX_OPEN;
			await Task.Delay(500);
			dialog.AddonMessage("NOTICE_Dm_Clear", "The treasure chest is empty!{nl}Right-click on the map and look for the next spot!");
			dialog.UnHideNPC("ROKAS30_TREASUREBOX99");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

