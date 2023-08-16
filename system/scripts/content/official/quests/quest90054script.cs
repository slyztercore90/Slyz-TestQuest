//--- Melia Script -----------------------------------------------------------
// For Safety (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Aisol.
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

[QuestScript(90054)]
public class Quest90054Script : QuestScript
{
	protected override void Load()
	{
		SetId(90054);
		SetName("For Safety (2)");
		SetDescription("Talk to Dievdirbys Aisol");
		SetTrack("SProgress", "ESuccess", "KATYN_45_2_SQ_13_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_12"));
		AddPrerequisite(new LevelPrerequisite(249));

		AddObjective("kill0", "Kill 1 Sequoia", new KillObjective(107001, 1));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_ESOL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_ESOL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_2_SQ_13_ST", "KATYN_45_2_SQ_13", "Don't worry", "I will think about it"))
			{
				case 1:
					await dialog.Msg("KATYN_45_2_SQ_13_AG");
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
			await dialog.Msg("KATYN_45_2_SQ_13_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

