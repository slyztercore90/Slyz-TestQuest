//--- Melia Script -----------------------------------------------------------
// A Stronger Antidote(3)
//--- Description -----------------------------------------------------------
// Quest to Craft an Enhanced Antidote with Researcher Sireah.
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

[QuestScript(30214)]
public class Quest30214Script : QuestScript
{
	protected override void Load()
	{
		SetId(30214);
		SetName("A Stronger Antidote(3)");
		SetDescription("Craft an Enhanced Antidote with Researcher Sireah");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_9"));
		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new ItemPrerequisite("ORCHARD_34_3_SQ_ITEM3", -100), new ItemPrerequisite("ORCHARD_34_3_SQ_ITEM7", -100));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_34_3_SQ_10_select", "ORCHARD_34_3_SQ_10", "Give the Antidote and ingredients", "Say that you think it will be fine to eat seperately"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/ORCHARD_34_3_SQ_NPC_3/F_spread_in002_green/0.5/MID");
					await dialog.Msg("ORCHARD_34_3_SQ_10_agree");
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
			await dialog.Msg("ORCHARD_34_3_SQ_10_succ");
			dialog.HideNPC("ORCHARD_34_3_SQ_OBJ_9");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

