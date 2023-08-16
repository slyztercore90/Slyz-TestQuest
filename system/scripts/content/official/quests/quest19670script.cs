//--- Melia Script -----------------------------------------------------------
// Offering to the Angry Souls
//--- Description -----------------------------------------------------------
// Quest to Souls of the Altar.
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

[QuestScript(19670)]
public class Quest19670Script : QuestScript
{
	protected override void Load()
	{
		SetId(19670);
		SetName("Offering to the Angry Souls");
		SetDescription("Souls of the Altar");
		SetTrack("SProgress", "ESuccess", "PILGRIM50_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("kill0", "Kill 20 Kodomor(s) or Lomor(s) or Prison Fighter(s)", new KillObjective(20, 41450, 57403, 41315));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ANGRY02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_GHOST2", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("PILGRIM50_SQ_060_COMP");
			await dialog.Msg("EffectLocalNPC/PILGRIM50_GHOST2/I_bomb005_dark/1/BOT");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("PILGRIM50_GHOST2");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Calmed the soul!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

