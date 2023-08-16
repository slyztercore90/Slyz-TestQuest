//--- Melia Script -----------------------------------------------------------
// The dead body of the mercenary who has fallen
//--- Description -----------------------------------------------------------
// Quest to Body of the collapsed mercenary.
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

[QuestScript(19350)]
public class Quest19350Script : QuestScript
{
	protected override void Load()
	{
		SetId(19350);
		SetName("The dead body of the mercenary who has fallen");
		SetDescription("Body of the collapsed mercenary");
		SetTrack("SProgress", "ESuccess", "ROKAS30_MQ2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Hogma Warrior(s) or Hogma Archer(s) or Hogma Shaman(s)", new KillObjective(5, 41433, 41434, 41435));

		AddDialogHook("ROKAS30_MQ2_1_SCAR", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_MQ2_1_SCAR", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("ROKAS30_MQ2_1_SCAR");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've prayed for the dead soldier!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

