//--- Melia Script -----------------------------------------------------------
// Mirtinas Storage
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(92020)]
public class Quest92020Script : QuestScript
{
	protected override void Load()
	{
		SetId(92020);
		SetName("Mirtinas Storage");
		SetDescription("Speak with Goddess Lada");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_4_MQ03_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(456));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA4TO5", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_4_MQ_03_DLG1", "EP13_F_SIAULIAI_4_MQ_03", "I'll leave right away to the Issaugoti Forest", "I'm not ready yet."))
			{
				case 1:
					await dialog.Msg("EP13_F_SIAULIAI_4_MQ_03_DLG2");
					// Func/SCR_EP13_F_SIAULIAI_4_MQ03_WARP;
					dialog.HideNPC("EP13_GODDESS_LADA");
					dialog.UnHideNPC("EP13_GODDESS_LADA_ISA");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("EP13_F_SIAULIAI_4_MQ_03_DLG4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_4_MQ_04");
	}
}

