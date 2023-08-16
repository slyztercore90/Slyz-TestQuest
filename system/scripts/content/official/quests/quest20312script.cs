//--- Melia Script -----------------------------------------------------------
// Critical Situation
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius at Uola Chapel.
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

[QuestScript(20312)]
public class Quest20312Script : QuestScript
{
	protected override void Load()
	{
		SetId(20312);
		SetName("Critical Situation");
		SetDescription("Talk to Bishop Aurelius at Uola Chapel");
		SetTrack("SProgress", "ESuccess", "CHATHEDRAL54_MQ03_PART2_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ01_PART1"));
		AddPrerequisite(new LevelPrerequisite(141));

		AddObjective("kill0", "Kill 7 Blue Stoulet(s)", new KillObjective(57367, 7));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CATHEDRAL54_MQ02_PART2_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3666));

		AddDialogHook("CHATHEDRAL54_BISHOP_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CATHEDRAL54MQ02_OBJECT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL54_MQ03_PART2_select", "CHATHEDRAL54_MQ03_PART2", "I will retrieve the Holy Symbol of Spiritual Power", "Decline"))
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
			await dialog.Msg("EffectLocalNPC/CATHEDRAL54MQ02_OBJECT/F_pc_making_finish_white/1/BOT");
			dialog.HideNPC("CATHEDRAL54MQ02_OBJECT");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

