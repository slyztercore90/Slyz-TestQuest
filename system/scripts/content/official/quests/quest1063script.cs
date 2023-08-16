//--- Melia Script -----------------------------------------------------------
// The Eternal Adventure (4) - Deleted
//--- Description -----------------------------------------------------------
// Quest to Extinguished the research diary on the fire place.
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

[QuestScript(1063)]
public class Quest1063Script : QuestScript
{
	protected override void Load()
	{
		SetId(1063);
		SetName("The Eternal Adventure (4) - Deleted");
		SetDescription("Extinguished the research diary on the fire place");
		SetTrack("SProgress", "ESuccess", "ROKAS29_VACYS6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new ItemPrerequisite("VACYS_note", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_1", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_2", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_3", -100));

		AddDialogHook("ROKAS29_FIRE", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_SOUL", "BeforeEnd", BeforeEnd);
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
			dialog.HideNPC("VACYS_SOUL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

