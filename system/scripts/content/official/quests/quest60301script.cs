//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (4)
//--- Description -----------------------------------------------------------
// Quest to Remove the Kupole Traps.
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

[QuestScript(60301)]
public class Quest60301Script : QuestScript
{
	protected override void Load()
	{
		SetId(60301);
		SetName("The Fugitive's Dream (4)");
		SetDescription("Remove the Kupole Traps");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(378));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("DCAPITAL107_SQ_4_NPC");
	}
}

