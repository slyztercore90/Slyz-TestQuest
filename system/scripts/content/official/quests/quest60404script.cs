//--- Melia Script -----------------------------------------------------------
// Outer Wall Post (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60404)]
public class Quest60404Script : QuestScript
{
	protected override void Load()
	{
		SetId(60404);
		SetName("Outer Wall Post (1)");
		SetDescription("Talk to Pajauta");
		SetTrack("SProgress", "ESuccess", "PAYAUTA_EP11_5_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_4"));
		AddPrerequisite(new LevelPrerequisite(380));

		AddObjective("kill0", "Kill 6 Akhlass Countess(s) or Akhlacia(s) or Akhlass Petal(s) or Akhlass Steel(s)", new KillObjective(6, 58613, 58611, 58609, 58610));

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_TRG1", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_201", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("PAYAUTA_EP11_5_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

