//--- Melia Script -----------------------------------------------------------
// Caught in the Middle
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Raminta.
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

[QuestScript(20262)]
public class Quest20262Script : QuestScript
{
	protected override void Load()
	{
		SetId(20262);
		SetName("Caught in the Middle");
		SetDescription("Talk to Believer Raminta");
		SetTrack("SProgress", "ESuccess", "THORN20_MQ02_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 1 Rikaus", new KillObjective(400661, 1));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MQ02_BOSS", "BeforeStart", BeforeStart);
		AddDialogHook("THORN20_MQ02_BOSS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN20_MQ02_select01", "THORN20_MQ02", "I'll take care of it right away", "It will be safer to let the other Believers know "))
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
			await dialog.Msg("THORN20_MQ02_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

