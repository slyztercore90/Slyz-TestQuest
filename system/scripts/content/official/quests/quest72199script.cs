//--- Melia Script -----------------------------------------------------------
// Building Initiation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72199)]
public class Quest72199Script : QuestScript
{
	protected override void Load()
	{
		SetId(72199);
		SetName("Building Initiation (1)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack("SPossible", "ESuccess", "STARTOWER_91_MQ_10_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_80"));
		AddPrerequisite(new LevelPrerequisite(382));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20246));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("STARTOWER_91_MQ_10_DLG1", "STARTOWER_91_MQ_10", "Alright", "Let's rest for a bit, can we?"))
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
			await dialog.Msg("STARTOWER_91_MQ_10_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

