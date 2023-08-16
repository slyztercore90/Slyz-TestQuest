//--- Melia Script -----------------------------------------------------------
// Stomp on the Sprouts
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70722)]
public class Quest70722Script : QuestScript
{
	protected override void Load()
	{
		SetId(70722);
		SetName("Stomp on the Sprouts");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ02"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN422_SQ_03_start", "BRACKEN42_2_SQ03", "How can I help you?", "That is beyond my power."))
			{
				case 1:
					await dialog.Msg("BRACKEN422_SQ_03_agree");
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
			await dialog.Msg("BRACKEN422_SQ_03_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

