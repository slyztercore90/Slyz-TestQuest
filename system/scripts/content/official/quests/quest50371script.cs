//--- Melia Script -----------------------------------------------------------
// Matador's Knowledge
//--- Description -----------------------------------------------------------
// Quest to Talk to the Matador Master.
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

[QuestScript(50371)]
public class Quest50371Script : QuestScript
{
	protected override void Load()
	{
		SetId(50371);
		SetName("Matador's Knowledge");
		SetDescription("Talk to the Matador Master");
		SetTrack("SProgress", "ESuccess", "JOB_MATADOR1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MATADOR_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MATADOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_MATADOR1_START1", "JOB_MATADOR1", "I'll do it", "I'm not interested"))
			{
				case 1:
					await dialog.Msg("JOB_MATADOR1_AGREE1");
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
			await dialog.Msg("JOB_MATADOR1_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

