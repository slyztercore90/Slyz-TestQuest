//--- Melia Script -----------------------------------------------------------
// The Battle Abilities of Scout [Scout Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout Submaster.
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

[QuestScript(30113)]
public class Quest30113Script : QuestScript
{
	protected override void Load()
	{
		SetId(30113);
		SetName("The Battle Abilities of Scout [Scout Advancement]");
		SetDescription("Talk to the Scout Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_SCOUT5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(57185, 1));

		AddDialogHook("JOB_2_SCOUT_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SCOUT_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_SCOUT_6_1_select", "JOB_2_SCOUT_6_1", "Tell me about the request", "That sounds dangerous; I'll pass"))
			{
				case 1:
					await dialog.Msg("JOB_2_SCOUT_6_1_agree");
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
			await dialog.Msg("JOB_2_SCOUT_6_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

