//--- Melia Script -----------------------------------------------------------
// Reclaimed Power Generator
//--- Description -----------------------------------------------------------
// Quest to Talk to Mulia.
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

[QuestScript(92005)]
public class Quest92005Script : QuestScript
{
	protected override void Load()
	{
		SetId(92005);
		SetName("Reclaimed Power Generator");
		SetDescription("Talk to Mulia");
		SetTrack("SProgress", "ESuccess", "EP12_2_D_DCAPITAL_108_MQ06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ05"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddObjective("kill0", "Kill 9 Raganosis Guardian(s) or Raganosis Ram(s) or Raganosis Seeker(s)", new KillObjective(9, 59527, 59530, 59528));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 41));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ06_DLG1", "EP12_2_D_DCAPITAL_108_MQ06", "Follow me, I'll lead the way.", "It would be better to take some rest here."))
			{
				case 1:
					// Func/SCR_DCAPITAL108_GUIDE3;
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
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ07");
	}
}

