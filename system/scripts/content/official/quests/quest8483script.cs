//--- Melia Script -----------------------------------------------------------
// Lunatic Wizard (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita at Mage Tower 3F.
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

[QuestScript(8483)]
public class Quest8483Script : QuestScript
{
	protected override void Load()
	{
		SetId(8483);
		SetName("Lunatic Wizard (1)");
		SetDescription("Talk to Grita at Mage Tower 3F");
		SetTrack("SProgress", "ESuccess", "FTOWER43_MQ_01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("FTOWER42_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("kill0", "Kill 8 Red Infrorocktor(s)", new KillObjective(57053, 8));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_GRITA_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_GRITA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER43_MQ_01_01", "FTOWER43_MQ_01", "Quick, follow me", "Let's rest for a while."))
			{
				case 1:
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
			await dialog.Msg("FTOWER43_MQ_01_03");
			dialog.HideNPC("FTOWER43_GRITA_01");
			await Task.Delay(500);
			// Func/FTOWER43_MQ_02_RUNNPC;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER43_MQ_02");
	}
}

