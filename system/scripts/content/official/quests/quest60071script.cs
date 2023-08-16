//--- Melia Script -----------------------------------------------------------
// The Journey Begins (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Brophen.
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

[QuestScript(60071)]
public class Quest60071Script : QuestScript
{
	protected override void Load()
	{
		SetId(60071);
		SetName("The Journey Begins (2)");
		SetDescription("Talk with Settler Brophen");
		SetTrack("SProgress", "ESuccess", "SIAU16_MQ_02_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Kepa(s)", new KillObjective(58005, 5));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU16_MQ_02_01", "SIAU16_MQ_02", "Monsters might come out", "There's no need to hurry"))
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

		return HookResult.Continue;
	}
}

