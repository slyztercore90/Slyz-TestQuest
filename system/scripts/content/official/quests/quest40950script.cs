//--- Melia Script -----------------------------------------------------------
// Someone's Record
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(40950)]
public class Quest40950Script : QuestScript
{
	protected override void Load()
	{
		SetId(40950);
		SetName("Someone's Record");
		SetDescription("Look at the pillar");
		SetTrack("SProgress", "ESuccess", "ROKAS_36_1_SQ_010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA01", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA01", "BeforeEnd", BeforeEnd);
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "As you brushed off black powders, you can see the engraved letters!");
			await dialog.Msg("EffectLocalNPC/ROKAS_36_1_PILLA01/F_ground139_light_green/1/BOT");
			await Task.Delay(2000);
			await dialog.Msg("ROKAS_36_1_SQ_010_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

