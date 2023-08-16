//--- Melia Script -----------------------------------------------------------
// Giant Bracken (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Traveling Merchant Rose to Dadan Jungle.
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

[QuestScript(50108)]
public class Quest50108Script : QuestScript
{
	protected override void Load()
	{
		SetId(50108);
		SetName("Giant Bracken (1)");
		SetDescription("Follow Traveling Merchant Rose to Dadan Jungle");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ060"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 10 Vubbe Warrior(s)", new KillObjective(103024, 10));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN_63_3_MQ010_startnpc01", "BRACKEN_63_3_MQ010", "I'll find the laboratory and take care of the demons there.", "Let's just go"))
			{
				case 1:
					dialog.HideNPC("BRACKEN632_ROZE03");
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("BRACKEN_63_3_MQ020");
	}
}

