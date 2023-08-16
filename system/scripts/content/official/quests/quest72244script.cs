//--- Melia Script -----------------------------------------------------------
// Creeping Darkness (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72244)]
public class Quest72244Script : QuestScript
{
	protected override void Load()
	{
		SetId(72244);
		SetName("Creeping Darkness (7)");
		SetDescription("Talk to Neringa");
		SetTrack("SPossible", "ESuccess", "EP12_PRELUDE_07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_06"));
		AddPrerequisite(new LevelPrerequisite(420));

		AddReward(new ItemReward("Vis", 24360));
		AddReward(new ItemReward("expCard16", 2));

		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_106A", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_106B", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_PRELUDE_07_DLG01", "EP12_PRELUDE_07", "Alright", "Give me some time to prepare"))
			{
				case 1:
					dialog.HideNPC("EP12_PRELUDE_NERINGA_DCAPITAL_106A");
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
			await dialog.Msg("EP12_PRELUDE_07_DLG02");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

