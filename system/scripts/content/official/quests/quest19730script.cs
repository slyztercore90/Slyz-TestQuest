//--- Melia Script -----------------------------------------------------------
// Worship for the Blessing (2)
//--- Description -----------------------------------------------------------
// Quest to Offer Worship to the Sanctum.
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

[QuestScript(19730)]
public class Quest19730Script : QuestScript
{
	protected override void Load()
	{
		SetId(19730);
		SetName("Worship for the Blessing (2)");
		SetDescription("Offer Worship to the Sanctum");
		SetTrack("SProgress", "ESuccess", "PILGRIM51_SQ_2_1_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_2"));
		AddPrerequisite(new LevelPrerequisite(129));

		AddObjective("kill0", "Kill 15 Prison Fighter(s) or Kowak(s) or Kodomor(s)", new KillObjective(15, 41315, 41451, 41450));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR02", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("PILGRIM51_SQ_2_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM51_SQ_2_2");
	}
}

