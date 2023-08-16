//--- Melia Script -----------------------------------------------------------
// Worrisome Disappearances (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Glen.
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

[QuestScript(4419)]
public class Quest4419Script : QuestScript
{
	protected override void Load()
	{
		SetId(4419);
		SetName("Worrisome Disappearances (2)");
		SetDescription("Talk to Mercenary Glen");
		SetTrack("SProgress", "ESuccess", "ROKAS27_QB_7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 11 Tucen(s) or Ticen(s)", new KillObjective(11, 57046, 57045));

		AddDialogHook("ROKAS27_GLEN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_GLEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS27_QB_7_select1", "ROKAS27_QB_7", "I'll defeat the monsters", "I'll get going now"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ROKAS27_QB_7_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

