//--- Melia Script -----------------------------------------------------------
// Finding the Model [Dievdirbys Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Klaipeda Item Merchant.
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

[QuestScript(1131)]
public class Quest1131Script : QuestScript
{
	protected override void Load()
	{
		SetId(1131);
		SetName("Finding the Model [Dievdirbys Advancement] (3)");
		SetDescription("Talk to Klaipeda Item Merchant");

		AddPrerequisite(new CompletedPrerequisite("JOB_DIEVDIRBYS3_2"));
		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("EMILIA", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_DIEVDIRBYS3_3_select1", "JOB_DIEVDIRBYS3_3", "Let's go catch a cat", "Let's rest before catching the cat."))
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
			await dialog.Msg("JOB_DIEVDIRBYS3_3_succ1");
			dialog.UnHideNPC("JOB_DIEVDIRBYS3_3_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

