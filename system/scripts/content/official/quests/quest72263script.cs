//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (4)
//--- Description -----------------------------------------------------------
// Quest to Return to Goddess Laima.
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

[QuestScript(72263)]
public class Quest72263Script : QuestScript
{
	protected override void Load()
	{
		SetId(72263);
		SetName("Dusk and Dawn (4)");
		SetDescription("Return to Goddess Laima");
		SetTrack("SPossible", "ESuccess", "EP12_FINALE_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_03"));
		AddPrerequisite(new LevelPrerequisite(446));

		AddObjective("kill0", "Kill 1 Glutton Kabad", new KillObjective(105032, 1));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 26314));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_FINALE_DIRECTION_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP12_FINALE_04_DLG13");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.HideNPC("EP12_FINALE_RAIMA01");
	}
}

