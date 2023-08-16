//--- Melia Script -----------------------------------------------------------
// Discarding Blind Shells (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(50054)]
public class Quest50054Script : QuestScript
{
	protected override void Load()
	{
		SetId(50054);
		SetName("Discarding Blind Shells (2)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_65_SQ010"));
		AddPrerequisite(new LevelPrerequisite(200));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS_65_SQ020_startnpc01", "UNDERFORTRESS_65_SQ020", "I will try finding it", "Tell him that you would do it later"))
			{
				case 1:
					await dialog.Msg("UNDER_65_SQ020_startnpc02");
					dialog.UnHideNPC("UNDER65_SQ02_BOMB_RANGE01");
					dialog.UnHideNPC("UNDER65_SQ02_BOMB_RANGE02");
					dialog.UnHideNPC("UNDER65_SQ02_BOMB_RANGE03");
					dialog.UnHideNPC("UNDER65_SQ02_BOMB_RANGE04");
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("UNDERFORTRESS_65_SQ020_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

