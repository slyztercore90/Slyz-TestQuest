//--- Melia Script -----------------------------------------------------------
// Crystal Stone in the Courtyard
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Solcomm.
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

[QuestScript(72117)]
public class Quest72117Script : QuestScript
{
	protected override void Load()
	{
		SetId(72117);
		SetName("Crystal Stone in the Courtyard");
		SetDescription("Talk to Demon Lord Solcomm");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE262_SQ03_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ02"));
		AddPrerequisite(new LevelPrerequisite(336));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE262_SQ03_DLG01", "F_3CMLAKE262_SQ03", "Alright", "It's too difficult for me."))
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
			await dialog.Msg("3CMLAKE262_SQ03_DLG03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

