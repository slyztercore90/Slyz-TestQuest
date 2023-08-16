//--- Melia Script -----------------------------------------------------------
// Disarming the Defense System (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(72179)]
public class Quest72179Script : QuestScript
{
	protected override void Load()
	{
		SetId(72179);
		SetName("Disarming the Defense System (1)");
		SetDescription("Talk to Resistance Deputy Commander Kron");
		SetTrack("SProgress", "ESuccess", "STARTOWER_88_MQ_70_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_88_MQ_20"));
		AddPrerequisite(new LevelPrerequisite(372));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 58032));

		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("STARTOWER_88_MQ_70_DLG1", "STARTOWER_88_MQ_70", "Alright", "I need time to rest."))
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
			await dialog.Msg("STARTOWER_88_MQ_70_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

