//--- Melia Script -----------------------------------------------------------
// Know Your Enemy, Know Yourself (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Schaffenstar Adjutant Apollonius.
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

[QuestScript(72222)]
public class Quest72222Script : QuestScript
{
	protected override void Load()
	{
		SetId(72222);
		SetName("Know Your Enemy, Know Yourself (5)");
		SetDescription("Talk to Schaffenstar Adjutant Apollonius");
		SetTrack("SPossible", "ESuccess", "CASTLE93_MAIN07_BEFORE_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE93_MAIN06"));
		AddPrerequisite(new LevelPrerequisite(392));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20723));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE93_MAIN07_01", "CASTLE93_MAIN07", "Alright", "Give me some time to prepare"))
			{
				case 1:
					dialog.HideNPC("F_3CMLAKE_85_MQ_11_NPC");
					dialog.UnHideNPC("CASTLE93_NPC_18");
					dialog.UnHideNPC("CASTLE93_NPC_19");
					dialog.UnHideNPC("CASTLE93_NPC_20");
					dialog.UnHideNPC("CASTLE93_NPC_21");
					dialog.UnHideNPC("CASTLE93_NPC_22");
					dialog.UnHideNPC("CASTLE93_NPC_23");
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
			await dialog.Msg("CASTLE93_MAIN07_03");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

