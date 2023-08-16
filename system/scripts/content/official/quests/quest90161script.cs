//--- Melia Script -----------------------------------------------------------
// De-Contruction  [Cannoneer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Canonneer Master.
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

[QuestScript(90161)]
public class Quest90161Script : QuestScript
{
	protected override void Load()
	{
		SetId(90161);
		SetName("De-Contruction  [Cannoneer Advancement]");
		SetDescription("Talk with the Canonneer Master");
		SetTrack("SProgress", "ESuccess", "JOB_CANNONEER_8_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 1 Fake Observation Orb", new KillObjective(58533, 1));

		AddDialogHook("CANNONEER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("CANNONEER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_CANNONEER_8_1_ST", "JOB_CANNONEER_8_1", "Don't worry. I will do it.", "If it is something dangerous, I can't do it."))
			{
				case 1:
					await dialog.Msg("JOB_CANNONEER_8_1_AG");
					dialog.UnHideNPC("JOB_CANNONEER_8_1");
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
			await dialog.Msg("JOB_CANNONEER_8_1_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

