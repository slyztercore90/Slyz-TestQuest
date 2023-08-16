//--- Melia Script -----------------------------------------------------------
// Swore to Protect (11)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Medeina.
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

[QuestScript(80437)]
public class Quest80437Script : QuestScript
{
	protected override void Load()
	{
		SetId(80437);
		SetName("Swore to Protect (11)");
		SetDescription("Talk to Goddess Medeina");
		SetTrack("SPossible", "EPossible", "F_MAPLE_24_2_MQ_11_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(415));

		AddReward(new ExpReward(146411152, 146411152));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 106));

		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_11_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("F_MAPLE_24_2_MQ_11_SU");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

