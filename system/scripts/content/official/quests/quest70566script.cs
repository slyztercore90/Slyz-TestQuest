//--- Melia Script -----------------------------------------------------------
// Interferance
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70566)]
public class Quest70566Script : QuestScript
{
	protected override void Load()
	{
		SetId(70566);
		SetName("Interferance");
		SetDescription("Talk to Monk Stella");
		SetTrack("SProgress", "ESuccess", "PILGRIM41_3_SQ07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ06"));
		AddPrerequisite(new LevelPrerequisite(268));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM413_SQ_07_start", "PILGRIM41_3_SQ07", "Ask if there is another way", "Say that you do not wish to do so because it is from the Order"))
			{
				case 1:
					await dialog.Msg("PILGRIM413_SQ_07_agree");
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
			await dialog.Msg("PILGRIM413_SQ_07_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

