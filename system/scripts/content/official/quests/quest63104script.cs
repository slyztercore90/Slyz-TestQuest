//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(63104)]
public class Quest63104Script : QuestScript
{
	protected override void Load()
	{
		SetId(63104);
		SetName("Revelator of Moroth (3)");
		SetDescription("Talk to General Ramin");

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("EP14_RAMIN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_MULIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_3LINE_TUTO_MQ_3_1", "EP14_3LINE_TUTO_MQ_3", "Alright", "Decline"))
			{
				case 1:
					dialog.AddonMessage("NOTICE_Dm_Scroll", "Illusion of the Girl is looking for you.");
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
			await dialog.Msg("EP14_3LINE_TUTO_MQ_3_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_3_1");
	}
}

