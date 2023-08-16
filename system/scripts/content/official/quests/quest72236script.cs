//--- Melia Script -----------------------------------------------------------
// Mission Complete
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Antanina.
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

[QuestScript(72236)]
public class Quest72236Script : QuestScript
{
	protected override void Load()
	{
		SetId(72236);
		SetName("Mission Complete");
		SetDescription("Talk to Resistance Adjutant Antanina");
		SetTrack("SProgress", "ESuccess", "CASTLE95_MAIN07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE95_MAIN06"));
		AddPrerequisite(new LevelPrerequisite(398));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_NPC_MAIN02", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE95_NPC_MAIN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE95_MAIN07_01", "CASTLE95_MAIN07", "Alright", "Tell him to do it himself"))
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
			await dialog.Msg("CASTLE95_MAIN07_03");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

