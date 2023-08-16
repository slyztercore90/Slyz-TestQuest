//--- Melia Script -----------------------------------------------------------
// Unreasonable Defeat
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60031)]
public class Quest60031Script : QuestScript
{
	protected override void Load()
	{
		SetId(60031);
		SetName("Unreasonable Defeat");
		SetDescription("Talk to Kupole Arune");

		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(154));

		AddObjective("kill0", "Kill 8 Guardian Spider(s) or Nuka(s) or Elet(s)", new KillObjective(8, 57692, 57690, 57688));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4466));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON512_SQ_01_01", "VPRISON512_SQ_01", "I will come back after defeating it", "I will do it next time"))
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
			await dialog.Msg("VPRISON512_SQ_01_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

