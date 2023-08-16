//--- Melia Script -----------------------------------------------------------
// How to beat stronger foes(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30151)]
public class Quest30151Script : QuestScript
{
	protected override void Load()
	{
		SetId(30151);
		SetName("How to beat stronger foes(3)");
		SetDescription("Talk to Zanas' Soul");
		SetTrack("SProgress", "ESuccess", "PRISON_78_MQ_7_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(259));

		AddObjective("kill0", "Kill 1 Mandara", new KillObjective(58431, 1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10360));

		AddDialogHook("PRISON_78_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON_78_MQ_7_select", "PRISON_78_MQ_7", "Say that you will defeat Mandara", "Say that you need some more time"))
			{
				case 1:
					await dialog.Msg("PRISON_78_MQ_7_agree");
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
			await dialog.Msg("PRISON_78_MQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

