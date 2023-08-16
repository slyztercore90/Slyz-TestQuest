//--- Melia Script -----------------------------------------------------------
// Sealing the Stone Tower
//--- Description -----------------------------------------------------------
// Quest to Sealing the Stone Tower.
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

[QuestScript(40770)]
public class Quest40770Script : QuestScript
{
	protected override void Load()
	{
		SetId(40770);
		SetName("Sealing the Stone Tower");
		SetDescription("Sealing the Stone Tower");
		SetTrack("SProgress", "ESuccess", "REMAINS37_3_SQ_110_TRACK", "m_boss_b");

		// Required quest doesn't exist anymore, so disabling requirement.
/**		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_110_CON"));
		**/
		AddPrerequisite(new LevelPrerequisite(176));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(57696, 1));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));
	}
}

