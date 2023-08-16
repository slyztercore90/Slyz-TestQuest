//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60283)]
public class Quest60283Script : QuestScript
{
	protected override void Load()
	{
		SetId(60283);
		SetName("The Vulnerable Fugitive (3)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_2"));
		AddPrerequisite(new LevelPrerequisite(371));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("DCAPITAL105_GRISIA_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL105_SQ_3_1", "DCAPITAL105_SQ_3", "I'll take care of it", "I need to prepare"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("DCAPITAL105_SQ_4");
	}
}

