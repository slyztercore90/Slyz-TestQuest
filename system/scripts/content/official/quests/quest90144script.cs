//--- Melia Script -----------------------------------------------------------
// Trace Race (4)
//--- Description -----------------------------------------------------------
// Quest to Inspect Demon Lord Diena.
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

[QuestScript(90144)]
public class Quest90144Script : QuestScript
{
	protected override void Load()
	{
		SetId(90144);
		SetName("Trace Race (4)");
		SetDescription("Inspect Demon Lord Diena");
		SetTrack("SPossible", "ESuccess", "F_DCAPITAL_20_6_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(295));
	}
}

