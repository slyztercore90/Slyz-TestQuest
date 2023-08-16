//--- Melia Script -----------------------------------------------------------
// Remove Mirtinas (2)
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

[QuestScript(91157)]
public class Quest91157Script : QuestScript
{
	protected override void Load()
	{
		SetId(91157);
		SetName("Remove Mirtinas (2)");
		SetDescription("Remove the Mirtinas");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE3_MQ_3_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(478));

		AddObjective("kill0", "Kill 6 Blickferret Scout(s) or Eerie Blickferret(s)", new KillObjective(6, 59750, 59751));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE3_MQ_4");
	}
}

