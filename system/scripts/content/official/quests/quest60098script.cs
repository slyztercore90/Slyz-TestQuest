//--- Melia Script -----------------------------------------------------------
// Monster Colony (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Monster Nest in Bonan Forest Road.
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

[QuestScript(60098)]
public class Quest60098Script : QuestScript
{
	protected override void Load()
	{
		SetId(60098);
		SetName("Monster Colony (2)");
		SetDescription("Destroy the Monster Nest in Bonan Forest Road");
		SetTrack("SProgress", "ESuccess", "SIAU15RE_SQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Chafer", new KillObjective(57996, 1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAU15RE_SQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_RIGITESS", "BeforeEnd", BeforeEnd);
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

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("SIAU15RE_SQ_05_NPC");
	}
}

