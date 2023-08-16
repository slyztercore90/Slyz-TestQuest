//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (6)
//--- Description -----------------------------------------------------------
// Quest to Check the Oil Barrel Storage Room.
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

[QuestScript(30236)]
public class Quest30236Script : QuestScript
{
	protected override void Load()
	{
		SetId(30236);
		SetName("Inspect Inner Wall District 9 (6)");
		SetDescription("Check the Oil Barrel Storage Room");
		SetTrack("SProgress", "ESuccess", "CASTLE_20_2_SQ_6_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddObjective("kill0", "Kill 8 Akhlass Bishop(s)", new KillObjective(58612, 8));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));
	}
}

