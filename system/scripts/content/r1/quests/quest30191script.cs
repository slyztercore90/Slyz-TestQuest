//--- Melia Script -----------------------------------------------------------
// What Must Be Done (4)
//--- Description -----------------------------------------------------------
// Quest to Defeat the Demons by using the Worn Gravity Stone.
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

[QuestScript(30191)]
public class Quest30191Script : QuestScript
{
	protected override void Load()
	{
		SetId(30191);
		SetName("What Must Be Done (4)");
		SetDescription("Defeat the Demons by using the Worn Gravity Stone");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_7"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the Worn Gravity Stone on monsters", 5);
	}
}

