//--- Melia Script -----------------------------------------------------------
// Checking with Divine Water
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Vados.
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

[QuestScript(70545)]
public class Quest70545Script : QuestScript
{
	protected override void Load()
	{
		SetId(70545);
		SetName("Checking with Divine Water");
		SetDescription("Talk to Pilgrim Vados");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ05"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM414_SQ_06_start", "PILGRIM41_4_SQ06", "Say that you will test it at once", "Ask whether you can't simply spray it first"))
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
			await dialog.Msg("PILGRIM414_SQ_06_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

