//--- Melia Script -----------------------------------------------------------
// The End of Gaigalas
//--- Description -----------------------------------------------------------
// Quest to Summon and Defeat Gaigalas.
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

[QuestScript(4408)]
public class Quest4408Script : QuestScript
{
	protected override void Load()
	{
		SetId(4408);
		SetName("The End of Gaigalas");
		SetDescription("Summon and Defeat Gaigalas");
		SetTrack("SProgress", "ESuccess", "THORN23_BOSSKILL_1_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_17"));
		AddPrerequisite(new LevelPrerequisite(123));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(57056, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3075));
	}
}

