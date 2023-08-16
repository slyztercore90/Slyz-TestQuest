//--- Melia Script -----------------------------------------------------------
// Creeping Darkness (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72240)]
public class Quest72240Script : QuestScript
{
	protected override void Load()
	{
		SetId(72240);
		SetName("Creeping Darkness (3)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_02"));
		AddPrerequisite(new LevelPrerequisite(420));

		AddReward(new ItemReward("Vis", 24360));
		AddReward(new ItemReward("expCard16", 2));

		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_105A", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_105A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_PRELUDE_03_DLG01", "EP12_PRELUDE_03", "Alright", "Say you will do something else first"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_PRELUDE_04");
	}
}

