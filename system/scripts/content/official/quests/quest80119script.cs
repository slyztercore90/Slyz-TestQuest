//--- Melia Script -----------------------------------------------------------
// To the Goddess' Refuge (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80119)]
public class Quest80119Script : QuestScript
{
	protected override void Load()
	{
		SetId(80119);
		SetName("To the Goddess' Refuge (3)");
		SetDescription("Talk to Kupole Trija");
		SetTrack("SProgress", "ESuccess", "LIMESTONE_52_1_MQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(287));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LIMESTONE_52_1_MQ_7_start", "LIMESTONE_52_1_MQ_7", "I will protect you", "I can't; it's too dangerous."))
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
			await dialog.Msg("LIMESTONE_52_1_MQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

