//--- Melia Script -----------------------------------------------------------
// Goddess Gabija
//--- Description -----------------------------------------------------------
// Quest to Use the Jewel of Prominence.
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

[QuestScript(8498)]
public class Quest8498Script : QuestScript
{
	protected override void Load()
	{
		SetId(8498);
		SetName("Goddess Gabija");
		SetDescription("Use the Jewel of Prominence");
		SetTrack("SProgress", "ESuccess", "FTOWER45_MQ_05_GABIA_END_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_PRO"));
		AddPrerequisite(new LevelPrerequisite(126));

		AddReward(new ExpReward(690282, 690282));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 106));
		AddReward(new ItemReward("stonetablet05", 1));
		AddReward(new ItemReward("Vis", 40950));

		AddDialogHook("FTOWER45_MQ_05_D", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_MQ_06_D", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("FTOWER45_MQ_06_succ");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

