//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50390)]
public class Quest50390Script : QuestScript
{
	protected override void Load()
	{
		SetId(50390);
		SetName("The Feline Post Town Case (4)");
		SetDescription("Talk to Auguste Dupin");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(384));

		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUB5_NPC1_IN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("NICOPOLIS812_SQ04_START1", "F_NICOPOLIS_81_2_SQ_04", "I'll look for the Watch Guard.", "Leave this place"))
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
			await dialog.Msg("BalloonText/NICO812_SUB5_NPC1_IN_MSG1/7");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_NICOPOLIS_81_2_SQ_05");
	}
}

