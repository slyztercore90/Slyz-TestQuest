//--- Melia Script -----------------------------------------------------------
// Wandering Spirits (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Quiet Owl Sculpture.
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

[QuestScript(90068)]
public class Quest90068Script : QuestScript
{
	protected override void Load()
	{
		SetId(90068);
		SetName("Wandering Spirits (2)");
		SetDescription("Talk to Quiet Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_13"));
		AddPrerequisite(new LevelPrerequisite(253));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_OWL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_OWL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_3_SQ_14_ST", "KATYN_45_3_SQ_14", "I will bring it", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("KATYN_45_3_SQ_14_STD");
					dialog.UnHideNPC("KATYN_45_3_SQ_14_SOUL");
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
			await dialog.Msg("KATYN_45_3_SQ_14_SU");
			dialog.HideNPC("KATYN_45_3_SQ_14_SOUL");
			// Func/SCR_KATYN_45_3_SQ_14_SUCC_RUN;
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

