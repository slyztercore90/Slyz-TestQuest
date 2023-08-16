//--- Melia Script -----------------------------------------------------------
// The Souls of the Fallens
//--- Description -----------------------------------------------------------
// Quest to Talk to the soul of Victoras.
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

[QuestScript(70704)]
public class Quest70704Script : QuestScript
{
	protected override void Load()
	{
		SetId(70704);
		SetName("The Souls of the Fallens");
		SetDescription("Talk to the soul of Victoras");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ04"));
		AddPrerequisite(new LevelPrerequisite(278));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN421_SQ_05_start", "BRACKEN42_1_SQ05", "I will lead them myself.", "It's better if you do it."))
			{
				case 1:
					await dialog.Msg("BRACKEN421_SQ_05_agree");
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
			await dialog.Msg("BRACKEN421_SQ_05_succ");
			dialog.HideNPC("BRACKEN421_SQ_05");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

