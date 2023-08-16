//--- Melia Script -----------------------------------------------------------
// The Order's Scheme
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Mattas.
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

[QuestScript(70583)]
public class Quest70583Script : QuestScript
{
	protected override void Load()
	{
		SetId(70583);
		SetName("The Order's Scheme");
		SetDescription("Talk to Monk Mattas");
		SetTrack("SProgress", "ESuccess", "SCR_PILGRIM415_SQ_04_TRACKSTART", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ03"));
		AddPrerequisite(new LevelPrerequisite(271));

		AddDialogHook("PILGRIM415_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM415_SQ_04_start", "PILGRIM41_5_SQ04", "Say that it cannot be helped", "Decline stating that you cannot trust those from the Order"))
			{
				case 1:
					// Func/SCR_PILGRIM415_SQ_04_P;
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
			await dialog.Msg("PILGRIM415_SQ_04_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

