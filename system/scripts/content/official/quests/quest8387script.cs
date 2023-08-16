//--- Melia Script -----------------------------------------------------------
// Guardian Destructors (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(8387)]
public class Quest8387Script : QuestScript
{
	protected override void Load()
	{
		SetId(8387);
		SetName("Guardian Destructors (3)");
		SetDescription("Talk to the Beholder");
		SetTrack("SProgress", "ESuccess", "ZACHA4F_MQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("ZACHA4F_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(92));

		AddObjective("kill0", "Kill 1 Bearkaras", new KillObjective(57081, 1));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("misc_BRC03_105_2", 1));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ZACHA4F_MQ_05_BLACKMAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA4F_MQ_05_01", "ZACHA4F_MQ_05", "Stop the last Guardian to prevent the Mausoleum from being destroyed", "Ignore"))
			{
				case 1:
					dialog.HideNPC("ZACHA4F_MQ_05_BLACKMAN");
					await dialog.Msg("FadeOutIN/2000");
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
}

