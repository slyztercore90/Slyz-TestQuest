//--- Melia Script -----------------------------------------------------------
// The Underground Tunnel
//--- Description -----------------------------------------------------------
// Quest to Talk to General Buros.
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

[QuestScript(70048)]
public class Quest70048Script : QuestScript
{
	protected override void Load()
	{
		SetId(70048);
		SetName("The Underground Tunnel");
		SetDescription("Talk to General Buros");

		AddPrerequisite(new LevelPrerequisite(155));

		AddObjective("kill0", "Kill 13 Pink Root Mole(s)", new KillObjective(57459, 13));

		AddReward(new ExpReward(142150, 142150));
		AddReward(new ItemReward("expCard8", 1));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_3_SQ_03_1", "FARM49_3_SQ03", "I'll do it", "Reject it since you don't feel good about it"))
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
			await dialog.Msg("FARM49_3_SQ_03_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

