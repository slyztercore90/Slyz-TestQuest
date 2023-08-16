//--- Melia Script -----------------------------------------------------------
// Mining Facility of Woods of the Linked Bridges
//--- Description -----------------------------------------------------------
// Quest to Hear about the plans of the Woods of Linked Bridge from Goddess Lada.
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

[QuestScript(91039)]
public class Quest91039Script : QuestScript
{
	protected override void Load()
	{
		SetId(91039);
		SetName("Mining Facility of Woods of the Linked Bridges");
		SetDescription("Hear about the plans of the Woods of Linked Bridge from Goddess Lada");
		SetTrack("SPossible", "ESuccess", "EP13_F_SIAULIAI_2_MQ_01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(452));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_01_DLG1", "EP13_F_SIAULIAI_2_MQ_01", "Orsha's recovery comes first, I'll fight together ", "I don't want to get involved with the Gods"))
			{
				case 1:
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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
			await dialog.Msg("EP13_F_SIAULIAI_2_MQ_01_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

