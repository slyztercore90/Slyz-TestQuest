//--- Melia Script -----------------------------------------------------------
// Unexpected Results
//--- Description -----------------------------------------------------------
// Quest to Talk to Tenant Farmer Charlotte.
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

[QuestScript(70030)]
public class Quest70030Script : QuestScript
{
	protected override void Load()
	{
		SetId(70030);
		SetName("Unexpected Results");
		SetDescription("Talk to Tenant Farmer Charlotte");

		AddPrerequisite(new CompletedPrerequisite("FARM49_2_SQ03"));
		AddPrerequisite(new LevelPrerequisite(152));

		AddObjective("kill0", "Kill 12 Orange Tama(s)", new KillObjective(57352, 12));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_2_SQ_04_1", "FARM49_2_SQ04", "Tell her not to worry since you will defeat them", "Tell her to get rid of them on their own"))
			{
				case 1:
					await dialog.Msg("FARM49_2_SQ_04_2");
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
			await dialog.Msg("FARM49_2_SQ_04_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

