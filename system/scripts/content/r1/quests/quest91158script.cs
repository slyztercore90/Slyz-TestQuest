//--- Melia Script -----------------------------------------------------------
// Remove Mirtinas (3)
//--- Description -----------------------------------------------------------
// Quest to Remove the Mirtinas.
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

[QuestScript(91158)]
public class Quest91158Script : QuestScript
{
	protected override void Load()
	{
		SetId(91158);
		SetName("Remove Mirtinas (3)");
		SetDescription("Remove the Mirtinas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE3_MQ_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(478));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_3"));

		AddObjective("kill0", "Kill 6 Blickferret Scout(s) or Eerie Blickferret(s)", new KillObjective(6, 59750, 59751));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE3_MQ_5");
	}
}

