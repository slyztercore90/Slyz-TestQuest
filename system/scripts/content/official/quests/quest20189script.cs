//--- Melia Script -----------------------------------------------------------
// Rexipher, the Missing Historian (1)
//--- Description -----------------------------------------------------------
// Quest to Find out Historian Rexipher's whereabouts.
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

[QuestScript(20189)]
public class Quest20189Script : QuestScript
{
	protected override void Load()
	{
		SetId(20189);
		SetName("Rexipher, the Missing Historian (1)");
		SetDescription("Find out Historian Rexipher's whereabouts");

		AddPrerequisite(new CompletedPrerequisite("ROKAS29_MQ6"));
		AddPrerequisite(new LevelPrerequisite(76));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));

		AddDialogHook("ROKAS30_BAIL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS30_MQ1_select01", "ROKAS30_MQ1", "I'll ask another historian", "Stop looking for Rexipher"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

