//--- Melia Script -----------------------------------------------------------
// Earth Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80104)]
public class Quest80104Script : QuestScript
{
	protected override void Load()
	{
		SetId(80104);
		SetName("Earth Energy");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_35_2_SQ_6_start", "CORAL_35_2_SQ_6", "I'll gather the energy.", "That sounds dangerous"))
			{
				case 1:
					await dialog.Msg("NPCAin/CORAL_35_2_LUTAS_2/bury/1");
					dialog.UnHideNPC("CORAL_35_2_TERRA_MAKING");
					await dialog.Msg("EffectLocalNPC/CORAL_35_2_TERRA_MAKING/F_pattern015_white/1/BOT");
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
			// Func/CORAL_35_2_SHOCK_WAVE;
			await dialog.Msg("CORAL_35_2_SQ_6_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

