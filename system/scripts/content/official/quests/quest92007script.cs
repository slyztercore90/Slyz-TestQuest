//--- Melia Script -----------------------------------------------------------
// The Two Protective Devices (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rangda Master.
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

[QuestScript(92007)]
public class Quest92007Script : QuestScript
{
	protected override void Load()
	{
		SetId(92007);
		SetName("The Two Protective Devices (1)");
		SetDescription("Talk to the Rangda Master");
		SetTrack("SSuccess", "ESuccess", "EP12_2_D_DCAPITAL_108_MQ08_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ07"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddObjective("kill0", "Kill 8 Raganosis Guardian(s) or Raganosis Ram(s) or Raganosis Seeker(s)", new KillObjective(8, 59527, 59530, 59528));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ08_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ08_DLG1", "EP12_2_D_DCAPITAL_108_MQ08", "I will get rid of the remaining monsters.", "I am not ready to fight yet."))
			{
				case 1:
					// Func/SCR_DCAPITAL108_GUIDE4;
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ09");
	}
}

