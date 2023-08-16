//--- Melia Script -----------------------------------------------------------
// Creeping Darkness (4)
//--- Description -----------------------------------------------------------
// Quest to Stop the demons from destroying the Holy Namott.
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

[QuestScript(72241)]
public class Quest72241Script : QuestScript
{
	protected override void Load()
	{
		SetId(72241);
		SetName("Creeping Darkness (4)");
		SetDescription("Stop the demons from destroying the Holy Namott");
		SetTrack("SPossible", "ESuccess", "EP12_PRELUDE_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_03"));
		AddPrerequisite(new LevelPrerequisite(420));

		AddReward(new ItemReward("Vis", 24360));
		AddReward(new ItemReward("expCard16", 2));

		AddDialogHook("EP12_PRELUDE_04_START_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_105B", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_EP12_PRELUDE_NERINGA_DCAPITAL_105B_AFTER;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.HideNPC("EP12_PRELUDE_NERINGA_DCAPITAL_105A");
	}
}

