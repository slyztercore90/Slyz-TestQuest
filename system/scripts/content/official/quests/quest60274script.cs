//--- Melia Script -----------------------------------------------------------
// Shadow of the Black Wing (3)
//--- Description -----------------------------------------------------------
// Quest to Destroy Demon Dimensional Door.
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

[QuestScript(60274)]
public class Quest60274Script : QuestScript
{
	protected override void Load()
	{
		SetId(60274);
		SetName("Shadow of the Black Wing (3)");
		SetDescription("Destroy Demon Dimensional Door");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB485_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(347));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FANTASYLIB485_MQ_4");
	}
}

