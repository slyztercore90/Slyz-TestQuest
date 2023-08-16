//--- Melia Script -----------------------------------------------------------
// Magic Control (5)
//--- Description -----------------------------------------------------------
// Quest to Activate the Second Magic Control Device.
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

[QuestScript(91151)]
public class Quest91151Script : QuestScript
{
	protected override void Load()
	{
		SetId(91151);
		SetName("Magic Control (5)");
		SetDescription("Activate the Second Magic Control Device");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE2_MQ_8_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_7"));
		AddPrerequisite(new LevelPrerequisite(475));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_DCASTLE2_MANA2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_2_PAJAUTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP14_2_DCASTLE2_MQ_8_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE2_MQ_9");
	}
}

