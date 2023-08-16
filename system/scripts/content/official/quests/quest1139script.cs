//--- Melia Script -----------------------------------------------------------
// Assignment of Magic [Sorcerer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sorcerer Master.
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

[QuestScript(1139)]
public class Quest1139Script : QuestScript
{
	protected override void Load()
	{
		SetId(1139);
		SetName("Assignment of Magic [Sorcerer Advancement]");
		SetDescription("Talk to the Sorcerer Master");
		SetTrack("SProgress", "ESuccess", "JOB_SORCERER3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Security Guard", new KillObjective(10020, 1));

		AddDialogHook("JOB_SORCERER3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SORCERER3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_SORCERER3_1_select1", "JOB_SORCERER3_1", "Accept the duel with the Master", "Avoid the duel"))
			{
				case 1:
					await dialog.Msg("JOB_SORCERER3_1_agree1");
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
			await dialog.Msg("JOB_SORCERER3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

