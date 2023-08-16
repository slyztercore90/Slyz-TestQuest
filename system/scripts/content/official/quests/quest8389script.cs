//--- Melia Script -----------------------------------------------------------
// The Guardian's Jar (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Secret Guardian.
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

[QuestScript(8389)]
public class Quest8389Script : QuestScript
{
	protected override void Load()
	{
		SetId(8389);
		SetName("The Guardian's Jar (2)");
		SetDescription("Talk to the Secret Guardian");

		AddPrerequisite(new CompletedPrerequisite("ZACHA5F_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(93));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 69));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA5F_MQ_02_01", "ZACHA5F_MQ_02", "It's time to pour the source of the evil power in the jars", "I'm not ready yet"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("ZACHA5F_MQ_02_03");
			await dialog.Msg("CameraShockWaveLocal/2/99999/10/7/5/0");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You can hear someone crying out!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ZACHA5F_MQ_03");
	}
}

