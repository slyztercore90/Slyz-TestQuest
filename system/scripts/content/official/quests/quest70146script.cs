//--- Melia Script -----------------------------------------------------------
// Creating a Quiet Environment
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jones.
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

[QuestScript(70146)]
public class Quest70146Script : QuestScript
{
	protected override void Load()
	{
		SetId(70146);
		SetName("Creating a Quiet Environment");
		SetDescription("Talk to Monk Jones");

		AddPrerequisite(new LevelPrerequisite(179));

		AddObjective("kill0", "Kill 15 Liverwort(s)", new KillObjective(401481, 15));
		AddObjective("kill1", "Kill 15 Stonacon(s)", new KillObjective(57682, 15));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_3_SQ_01_1", "THORN39_3_SQ01", "I will defeat the monsters so don't worry", "It looks safe"))
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
			await dialog.Msg("THORN39_3_SQ_01_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

