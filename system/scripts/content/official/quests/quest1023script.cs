//--- Melia Script -----------------------------------------------------------
// Something Fishy
//--- Description -----------------------------------------------------------
// Quest to Talk to the Search Scout.
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

[QuestScript(1023)]
public class Quest1023Script : QuestScript
{
	protected override void Load()
	{
		SetId(1023);
		SetName("Something Fishy");
		SetDescription("Talk to the Search Scout");
		SetTrack("SProgress", "ESuccess", "SIAUL_WEST_ONION_BIG_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(3));

		AddObjective("kill0", "Kill 1 Large Kepa", new KillObjective(57407, 1));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 39));

		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_NAGLIS2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_WEST_ONION_BIG_ST", "SIAUL_WEST_ONION_BIG", "I'll take a look for you", "Cancel"))
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
			await dialog.Msg("SIAUL_WEST_ONION_BIG_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

