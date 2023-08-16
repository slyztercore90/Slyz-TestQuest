//--- Melia Script -----------------------------------------------------------
// Revelation of Fortress of the Land
//--- Description -----------------------------------------------------------
// Quest to Activate the Ruklys device to find the revelation.
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

[QuestScript(50084)]
public class Quest50084Script : QuestScript
{
	protected override void Load()
	{
		SetId(50084);
		SetName("Revelation of Fortress of the Land");
		SetDescription("Activate the Ruklys device to find the revelation");
		SetTrack("SProgress", "ESuccess", "UNDERFORTRESS_69_MQ060_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ050"));
		AddPrerequisite(new LevelPrerequisite(214));

		AddReward(new ExpReward(4160789, 4160789));
		AddReward(new ItemReward("stonetablet07", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 124));
		AddReward(new ItemReward("Vis", 67410));

		AddDialogHook("UNDER69_MQ5", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_69_2", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("UNDER_69_MQ060_succ01");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

