//--- Melia Script -----------------------------------------------------------
// Dealing with the remaining demons
//--- Description -----------------------------------------------------------
// Quest to Speak with Revelator Nichi.
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

[QuestScript(90209)]
public class Quest90209Script : QuestScript
{
	protected override void Load()
	{
		SetId(90209);
		SetName("Dealing with the remaining demons");
		SetDescription("Speak with Revelator Nichi");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_90"));
		AddPrerequisite(new LevelPrerequisite(331));

		AddObjective("kill0", "Kill 20 Nimrah Lancer(s) or Nimrah Soldier(s) or Varle Gunner(s) or Varle Hench(s) or Nimrah Duke(s)", new KillObjective(20, 58824, 58825, 58826, 58827, 58879));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_2_MAN3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_MAN3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_2_SQ_100_ST", "CORAL_44_2_SQ_100", "Of course", "It'll be difficult this time"))
			{
				case 1:
					await dialog.Msg("CORAL_44_2_SQ_100_AG");
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
			await dialog.Msg("CORAL_44_2_SQ_100_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

