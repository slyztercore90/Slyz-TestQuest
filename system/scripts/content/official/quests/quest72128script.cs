//--- Melia Script -----------------------------------------------------------
// Guilty Conscience (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(72128)]
public class Quest72128Script : QuestScript
{
	protected override void Load()
	{
		SetId(72128);
		SetName("Guilty Conscience (1)");
		SetDescription("Talk to the Sapper Master");
		SetTrack("SProgress", "ESuccess", "JOB_SAPPER2_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 6 Sapper Master's Hidden Goods(s)", new CollectItemObjective("JOB_SAPPER2_1_ITEM1", 6));
		AddDrop("JOB_SAPPER2_1_ITEM1", 10f, "Mallardu");

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_SAPPER1_1_DLG1", "MASTER_SAPPER1_1", "I can at least do that.", "I won't do something that sounds so suspicious."))
			{
				case 1:
					await dialog.Msg("JOB_SAPPER2_1_prog1");
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
		character.Quests.Start("MASTER_SAPPER1_2");
	}
}

