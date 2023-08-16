//--- Melia Script -----------------------------------------------------------
// The Wrong Faith
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Juta.
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

[QuestScript(80006)]
public class Quest80006Script : QuestScript
{
	protected override void Load()
	{
		SetId(80006);
		SetName("The Wrong Faith");
		SetDescription("Talk to Bokor Juta");
		SetTrack("SProgress", "ESuccess", "CATACOMB_33_1_SQ_07_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Abomination", new KillObjective(58154, 1));

		AddReward(new ExpReward(274320, 274320));
		AddReward(new ItemReward("expCard5", 6));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("CATACOMB_33_1_JUTA", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_JUTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_33_1_SQ_07_start", "CATACOMB_33_1_SQ_07", "I will go there first", "Give me some time to prepare"))
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_33_1_SQ_08");
	}
}

