//--- Melia Script -----------------------------------------------------------
// Where the Sun Shines [Pyromancer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Put the pot of the sun at Ramstis Ridge.
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

[QuestScript(1133)]
public class Quest1133Script : QuestScript
{
	protected override void Load()
	{
		SetId(1133);
		SetName("Where the Sun Shines [Pyromancer Advancement] (2)");
		SetDescription("Put the pot of the sun at Ramstis Ridge");

		AddPrerequisite(new CompletedPrerequisite("JOB_PYROMANCER3_1"));
		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_PYROMANCER3_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Clear", "Put the Sun Essence on the spot that Chapparition was guarding");
	}
}

