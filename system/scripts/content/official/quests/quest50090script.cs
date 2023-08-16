//--- Melia Script -----------------------------------------------------------
// Nervous Vendor
//--- Description -----------------------------------------------------------
// Quest to Talk with Varas.
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

[QuestScript(50090)]
public class Quest50090Script : QuestScript
{
	protected override void Load()
	{
		SetId(50090);
		SetName("Nervous Vendor");
		SetDescription("Talk with Varas");
		SetTrack("SProgress", "ESuccess", "BRACKEN_63_1_MQ010_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 7 Vubbe Chaser(s)", new KillObjective(103023, 7));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_TRADESMAN01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_ROZE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN_63_1_MQ010_startnpc01", "BRACKEN_63_1_MQ010", "Where?", "I'm running away; it's too dangerous"))
			{
				case 1:
					await dialog.Msg("BRACKEN_63_1_MQ010_startnpc02");
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

