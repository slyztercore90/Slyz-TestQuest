//--- Melia Script -----------------------------------------------------------
// Lost in the Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Izna.
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

[QuestScript(60080)]
public class Quest60080Script : QuestScript
{
	protected override void Load()
	{
		SetId(60080);
		SetName("Lost in the Forest (2)");
		SetDescription("Talk with Settler Izna");
		SetTrack("SProgress", "ESuccess", "SIAU16_SQ_04_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("SIAU16_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Woodspirit", new KillObjective(57994, 1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_IZNA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IZNA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU16_SQ_04_01", "SIAU16_SQ_04", "I will come back soon", "I don't think it'll be much use"))
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

