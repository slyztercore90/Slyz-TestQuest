//--- Melia Script -----------------------------------------------------------
// Deciphering the Mysterious Writings (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sage Master.
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

[QuestScript(50280)]
public class Quest50280Script : QuestScript
{
	protected override void Load()
	{
		SetId(50280);
		SetName("Deciphering the Mysterious Writings (2)");
		SetDescription("Talk with the Sage Master");

		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD362_HQ1"));
		AddPrerequisite(new LevelPrerequisite(151));

		AddDialogHook("SAGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIMROAD362_HQ2_start1", "PILGRIMROAD362_HQ2", "Do you have anything in mind?", "I have other issues to tend to, sorry."))
			{
				case 1:
					await dialog.Msg("PILGRIMROAD362_HQ2_agree1");
					await dialog.Msg("BalloonText/PILGRIMROAD362_HIDDENQ2_infor1/3");
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
			await dialog.Msg("PILGRIMROAD362_HQ2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIMROAD362_HQ3");
	}
}

