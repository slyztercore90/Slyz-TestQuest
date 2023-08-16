//--- Melia Script -----------------------------------------------------------
// Shadow of the Black Wing (6)
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

[QuestScript(60277)]
public class Quest60277Script : QuestScript
{
	protected override void Load()
	{
		SetId(60277);
		SetName("Shadow of the Black Wing (6)");
		SetDescription("Talk to Neringa");
		SetTrack("SProgress", "ESuccess", "FANTASYLIB485_MQ_6_TRACK", "m_boss_scenario3");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB485_MQ_5"));
		AddPrerequisite(new LevelPrerequisite(347));

		AddObjective("kill0", "Kill 1 Demon Lord Warpulis", new KillObjective(107029, 1));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY485_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY485_NERINGA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB485_MQ_6_1", "FANTASYLIB485_MQ_6", "I will fight back.", "I need to prepare"))
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
			await dialog.Msg("FANTASYLIB485_MQ_6_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

