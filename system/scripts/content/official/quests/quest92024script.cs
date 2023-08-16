//--- Melia Script -----------------------------------------------------------
// Divide and rule (4)
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

[QuestScript(92024)]
public class Quest92024Script : QuestScript
{
	protected override void Load()
	{
		SetId(92024);
		SetName("Divide and rule (4)");
		SetDescription("Speak with Goddess Lada");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_4_MQ07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(456));

		AddObjective("kill0", "Kill 4 Saugumas Sentinel(s)", new KillObjective(59587, 4));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_MQ08_BOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_4_MQ_07_DLG1", "EP13_F_SIAULIAI_4_MQ_07", "I'll check the Mirtinas Storage", "It's not the time yet"))
			{
				case 1:
					await dialog.Msg("EP13_F_SIAULIAI_4_MQ_07_DLG4");
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
			// Func/SCR_EP13_F_SIAULIAI_4_MQ07_GUIDE;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_4_MQ_08");
	}
}

