//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Delus.
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

[QuestScript(50060)]
public class Quest50060Script : QuestScript
{
	protected override void Load()
	{
		SetId(50060);
		SetName("Reclaim the Camp (5)");
		SetDescription("Talk to Royal Army Guard Delus");
		SetTrack("SProgress", "EComplete", "UNDERFORTRESS_66_MQ060_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ050"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddObjective("kill0", "Kill 1 Specter Monarch", new KillObjective(103021, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 49980));

		AddDialogHook("UNDER66_DELLOOS03", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_MQ07_GHOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS_66_MQ060_startnpc01", "UNDERFORTRESS_66_MQ060", "Alright", "Think about it one more time"))
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
			await dialog.Msg("UNDERFORTRESS_66_MQ060_succ01");
			// Func/UNDER66_MQ6_ITEM01_REMOVE;
			dialog.UnHideNPC("UNDER66_TO_UNDER65_SECRET_ROOM");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

