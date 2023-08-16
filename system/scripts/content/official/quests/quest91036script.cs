//--- Melia Script -----------------------------------------------------------
// Initiate the Investigation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91036)]
public class Quest91036Script : QuestScript
{
	protected override void Load()
	{
		SetId(91036);
		SetName("Initiate the Investigation (2)");
		SetDescription("Talk to the Goddess Lada");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_1_MQ_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_04_DLG1", "EP13_F_SIAULIAI_1_MQ_04", "Let's meet at Randoluma Rest Place", "That's too difficult to do now"))
			{
				case 1:
					// Func/SCR_EP13_F_SIAULIAI_1_MQ_LADA_1_HIDE;
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
			await dialog.Msg("EP13_F_SIAULIAI_1_MQ_04_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

