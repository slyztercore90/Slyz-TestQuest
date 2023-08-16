//--- Melia Script -----------------------------------------------------------
// Lunatic Wizard (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8484)]
public class Quest8484Script : QuestScript
{
	protected override void Load()
	{
		SetId(8484);
		SetName("Lunatic Wizard (2)");
		SetDescription("Talk to Grita");
		SetTrack("SProgress", "ESuccess", "FTOWER43_MQ_02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("FTOWER43_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("kill0", "Kill 1 Magic Valve", new KillObjective(147504, 1));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER43_MQ_02_01", "FTOWER43_MQ_02", "Let's stop Antares", "Just ignore it and go up "))
			{
				case 1:
					await dialog.Msg("FTOWER43_MQ_02_02");
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
			await dialog.Msg("FTOWER43_MQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER43_MQ_03");
	}
}

