//--- Melia Script -----------------------------------------------------------
// Releasing the Divine Power
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70581)]
public class Quest70581Script : QuestScript
{
	protected override void Load()
	{
		SetId(70581);
		SetName("Releasing the Divine Power");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ01"));
		AddPrerequisite(new LevelPrerequisite(271));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM415_SQ_02_start", "PILGRIM41_5_SQ02", "Ask if there is a way to destroy the Device", "Say that it does not look destructable"))
			{
				case 1:
					await dialog.Msg("PILGRIM415_SQ_02_agree");
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
			await dialog.Msg("PILGRIM415_SQ_02_succ");
			dialog.HideNPC("PILGRIM415_SQ_02");
			dialog.UnHideNPC("PILGRIM415_SQ_10_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

