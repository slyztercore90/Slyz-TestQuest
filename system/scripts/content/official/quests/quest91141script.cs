//--- Melia Script -----------------------------------------------------------
// Investigate the Barrier
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91141)]
public class Quest91141Script : QuestScript
{
	protected override void Load()
	{
		SetId(91141);
		SetName("Investigate the Barrier");
		SetDescription("Talk to Pajauta");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE1_MQ_8_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_7"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_2_1_PAJAUTA2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_PAJAUTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE1_MQ_8_DLG1", "EP14_2_DCASTLE1_MQ_8", "Alright", "I will come after doing something else."))
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

