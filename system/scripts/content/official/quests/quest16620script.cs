//--- Melia Script -----------------------------------------------------------
// The Revelators come First
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Dazine.
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

[QuestScript(16620)]
public class Quest16620Script : QuestScript
{
	protected override void Load()
	{
		SetId(16620);
		SetName("The Revelators come First");
		SetDescription("Talk to Priest Dazine");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_46_1_MQ_03_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(169));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_1_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_1_MQ_03_select", "SIAULIAI_46_1_MQ_03", "Leave it to me", "Give me some time to prepare"))
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
			await dialog.Msg("SIAULIAI_46_1_MQ_03_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_1_MQ_04");
	}
}

