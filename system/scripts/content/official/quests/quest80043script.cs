//--- Melia Script -----------------------------------------------------------
// Release the Goddess
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(80043)]
public class Quest80043Script : QuestScript
{
	protected override void Load()
	{
		SetId(80043);
		SetName("Release the Goddess");
		SetDescription("Speak with Goddess Lada");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORCHARD324_LADA", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_LADA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_324_MQ_03_start", "ORCHARD_324_MQ_03", "I'll try and destroy it", "It looks hard"))
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
		character.Quests.Start("ORCHARD_324_MQ_04");
	}
}

