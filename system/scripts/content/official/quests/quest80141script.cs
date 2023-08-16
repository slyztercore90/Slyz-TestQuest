//--- Melia Script -----------------------------------------------------------
// Kupole in the Darkness (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80141)]
public class Quest80141Script : QuestScript
{
	protected override void Load()
	{
		SetId(80141);
		SetName("Kupole in the Darkness (1)");
		SetDescription("Talk to Kupole Serija");
		SetTrack("SProgress", "ESuccess", "LIMESTONE_52_3_MQ_5_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(294));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_2", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LIMESTONE_52_3_MQ_5_start", "LIMESTONE_52_3_MQ_5", "Let's go in.", "I'm too scared."))
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
			dialog.UnHideNPC("LIMESTONECAVE_52_3_MEDENA_AI");
			await dialog.Msg("LIMESTONE_52_3_MQ_5_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

