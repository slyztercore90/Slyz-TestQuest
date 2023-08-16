//--- Melia Script -----------------------------------------------------------
// The Eternal Adventure (3)
//--- Description -----------------------------------------------------------
// Quest to Look for Varkis' Research Materials near Apatinis Cliff.
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

[QuestScript(1062)]
public class Quest1062Script : QuestScript
{
	protected override void Load()
	{
		SetId(1062);
		SetName("The Eternal Adventure (3)");
		SetDescription("Look for Varkis' Research Materials near Apatinis Cliff");
		SetTrack("SProgress", "ESuccess", "ROKAS29_VACYS5_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS4"));
		AddPrerequisite(new LevelPrerequisite(73));

		AddObjective("kill0", "Kill 5 Hogma Fighter(s) or Hogma Scout(s)", new KillObjective(5, 47308, 47309));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("VACYS_note_COM", 1));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("ROKAS29_SLATE3", "BeforeStart", BeforeStart);
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
			await dialog.Msg("ROKAS29_VACYS5_COMP");
			dialog.HideNPC("VACYS_SOUL");
			await dialog.Msg("FadeOutIN/2500");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Varkis' Spirit disappeared after leaving the completed documents!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

