//--- Melia Script -----------------------------------------------------------
// Old Story (6)
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

[QuestScript(8457)]
public class Quest8457Script : QuestScript
{
	protected override void Load()
	{
		SetId(8457);
		SetName("Old Story (6)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS40_MQ_06_01", "REMAINS40_MQ_06", "I'll charge the Spell Device.", "Decline"))
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
			await dialog.Msg("REMAINS40_MQ_06_03");
			await dialog.Msg("FadeOutIN/2000");
			dialog.UnHideNPC("REMAINS_40_DRUNK_03");
			dialog.HideNPC("REMAINS_40_DRUNK_02");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

