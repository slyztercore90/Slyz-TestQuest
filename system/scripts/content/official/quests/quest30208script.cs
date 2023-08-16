//--- Melia Script -----------------------------------------------------------
// Barha Forest's Antidote(4)
//--- Description -----------------------------------------------------------
// Quest to Cure Researcher Adas.
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

[QuestScript(30208)]
public class Quest30208Script : QuestScript
{
	protected override void Load()
	{
		SetId(30208);
		SetName("Barha Forest's Antidote(4)");
		SetDescription("Cure Researcher Adas");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EffectLocalNPC/ORCHARD_34_3_SQ_NPC_2/F_smoke115_green/2.0/BOT");
			await dialog.Msg("ORCHARD_34_3_SQ_4_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

