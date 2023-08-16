//--- Melia Script -----------------------------------------------------------
// Reactivating Narvas Temple
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50367)]
public class Quest50367Script : QuestScript
{
	protected override void Load()
	{
		SetId(50367);
		SetName("Reactivating Narvas Temple");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ12"));
		AddPrerequisite(new LevelPrerequisite(357));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY4", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_5_SUBQ14_PORTAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_5_SUBQ13_START1", "ABBEY22_5_SQ13", "I'll do it", "We can defeat all three Hauberks without using it."))
			{
				case 1:
					await dialog.Msg("ABBEY22_5_SUBQ13_AGR1");
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "Narvas Temple is being reactivated.{nl}Use the portal device to go to Hauberk.");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY22_5_SQ14");
	}
}

