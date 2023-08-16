//--- Melia Script -----------------------------------------------------------
// The hidden treasures(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(50042)]
public class Quest50042Script : QuestScript
{
	protected override void Load()
	{
		SetId(50042);
		SetName("The hidden treasures(2)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_080"));
		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeStart", BeforeStart);
		AddDialogHook("TRESURE01_BOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PARTY_Q_081_startnpc01", "PARTY_Q_081", "I will use it well", "I will find it later"))
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
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've found the treasure!");
			dialog.HideNPC("TRESURE01_BOX");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

