//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(3)
//--- Description -----------------------------------------------------------
// Quest to Search for Ebonypawn in the Food Storage.
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

[QuestScript(30258)]
public class Quest30258Script : QuestScript
{
	protected override void Load()
	{
		SetId(30258);
		SetName("Assassin Ebonypawn(3)");
		SetDescription("Search for Ebonypawn in the Food Storage");
		SetTrack("SProgress", "ESuccess", "CASTLE_20_4_SQ_5_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_4"));
		AddPrerequisite(new LevelPrerequisite(289));

		AddObjective("kill0", "Kill 1 Brickwall", new KillObjective(47255, 1));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));
	}
}

