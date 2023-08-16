//--- Melia Script -----------------------------------------------------------
// Swore to Protect (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Yulia.
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

[QuestScript(80433)]
public class Quest80433Script : QuestScript
{
	protected override void Load()
	{
		SetId(80433);
		SetName("Swore to Protect (7)");
		SetDescription("Talk to Kupole Yulia");
		SetTrack("SPossible", "ESuccess", "F_MAPLE_24_2_MQ_07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(415));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_242_MQ_06_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_MAPLE_24_2_MQ_07_ST", "F_MAPLE_24_2_MQ_07", "No, you do it.", "Okay, hold on."))
			{
				case 1:
					dialog.HideNPC("F_MAPLE_242_MQ_MEDEINA_NPC1");
					dialog.HideNPC("F_MAPLE_242_MQ_MEDEINA_EFFECT");
					dialog.UnHideNPC("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER");
					dialog.HideNPC("F_MAPLE_242_MQ_07_OBJ1");
					dialog.HideNPC("F_MAPLE_242_MQ_07_OBJ2");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("F_MAPLE_24_2_MQ_07_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

