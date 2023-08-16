//--- Melia Script -----------------------------------------------------------
// Irritating Pricks
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Erra.
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

[QuestScript(8602)]
public class Quest8602Script : QuestScript
{
	protected override void Load()
	{
		SetId(8602);
		SetName("Irritating Pricks");
		SetDescription("Talk to Watcher Erra");

		AddPrerequisite(new LevelPrerequisite(35));

		AddObjective("kill0", "Kill 8 Seedmia(s)", new KillObjective(57016, 8));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_ERRA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ERRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE574_MQ_02_01", "GELE574_MQ_02", "Sure, I'll defeat it", "Tell him to do it himself"))
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
			await dialog.Msg("GELE574_MQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

