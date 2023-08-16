//--- Melia Script -----------------------------------------------------------
// Hiding once more
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70849)]
public class Quest70849Script : QuestScript
{
	protected override void Load()
	{
		SetId(70849);
		SetName("Hiding once more");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ09"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES233_SQ_10_start", "WHITETREES23_3_SQ10", "Ask if there is anything else you can help with", "Say that your job is done since the entrance has been located"))
			{
				case 1:
					await dialog.Msg("WHITETREES233_SQ_10_agree");
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
			if (character.Inventory.HasItem("WHITETREES23_3_SQ10_ITEM", 14))
			{
				character.Inventory.RemoveItem("WHITETREES23_3_SQ10_ITEM", 14);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("WHITETREES233_SQ_10_succ1");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("WHITETREES233_SQ_08_3");
				dialog.UnHideNPC("WHITETREES233_SQ_08_2");
				await dialog.Msg("WHITETREES233_SQ_10_succ2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

