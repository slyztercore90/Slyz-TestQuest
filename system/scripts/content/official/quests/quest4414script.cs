//--- Melia Script -----------------------------------------------------------
// Business Interference (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Technician Heinen.
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

[QuestScript(4414)]
public class Quest4414Script : QuestScript
{
	protected override void Load()
	{
		SetId(4414);
		SetName("Business Interference (1)");
		SetDescription("Talk to Technician Heinen");

		AddPrerequisite(new LevelPrerequisite(67));

		AddObjective("kill0", "Kill 12 Sauga(s) or Ticen(s) or Tucen(s) or Loftlem(s)", new KillObjective(12, 401001, 57045, 57046, 57041));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_HEINEN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_HEINEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS27_QB_2_select1", "ROKAS27_QB_2", "I'll help you", "Just go back"))
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
			await dialog.Msg("ROKAS27_QB_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS27_QB_3");
	}
}

