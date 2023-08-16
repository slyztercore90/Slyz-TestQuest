//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Paulius.
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

[QuestScript(91063)]
public class Quest91063Script : QuestScript
{
	protected override void Load()
	{
		SetId(91063);
		SetName("Secrets Hidden Underground (8)");
		SetDescription("Talk to Paulius");
		SetTrack("SProgress", "ESuccess", "EP13_2_DPRISON2_MQ_8_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_7"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 1 Mokslas Vhaldobas", new KillObjective(59656, 1));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_5", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_2_DPRISON2_MQ_8_DLG1", "EP13_2_DPRISON2_MQ_8", "Alright", "Wait for a while"))
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
}

