//--- Melia Script -----------------------------------------------------------
// A Dark Entity
//--- Description -----------------------------------------------------------
// Quest to Defeat the uncontrollable Necroventer.
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

[QuestScript(8755)]
public class Quest8755Script : QuestScript
{
	protected override void Load()
	{
		SetId(8755);
		SetName("A Dark Entity");
		SetDescription("Defeat the uncontrollable Necroventer");
		SetTrack("SProgress", "ESuccess", "REMAIN38_SQ06_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("REMAIN38_SQ05"));
		AddPrerequisite(new LevelPrerequisite(99));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(57064, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ06", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAIN38_SQ06_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

