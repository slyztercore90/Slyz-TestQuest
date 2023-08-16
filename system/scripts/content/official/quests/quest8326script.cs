//--- Melia Script -----------------------------------------------------------
// The Wandering Soul (2)
//--- Description -----------------------------------------------------------
// Quest to Soul and conversation of Assistant.
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

[QuestScript(8326)]
public class Quest8326Script : QuestScript
{
	protected override void Load()
	{
		SetId(8326);
		SetName("The Wandering Soul (2)");
		SetDescription("Soul and conversation of Assistant");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_19"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Dark Slime(s)", new KillObjective(400781, 6));

		AddDialogHook("KATYN18_KEEPER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_KEEPER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_20_01", "KATYN18_MQ_20", "I'll get rid of the Dark Slime", "Cancel"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

