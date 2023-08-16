//--- Melia Script -----------------------------------------------------------
// The Old Manager's Identity
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50088)]
public class Quest50088Script : QuestScript
{
	protected override void Load()
	{
		SetId(50088);
		SetName("The Old Manager's Identity");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_68_MQ050"));
		AddPrerequisite(new LevelPrerequisite(211));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));

		AddDialogHook("EMINENT_68_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_68_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_68_MQ060_startnpc01", "UNDERFORTRESS_68_MQ060", "What happened? ", "Skip the explanation"))
			{
				case 1:
					await dialog.Msg("UNDER_68_MQ060_startnpc02");
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
			await dialog.Msg("UNDER_68_MQ060_succ01");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("EMINENT_68_1");
			dialog.UnHideNPC("AMANDA_68_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

