//--- Melia Script -----------------------------------------------------------
// The Past of the Spirits (5)
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

[QuestScript(50076)]
public class Quest50076Script : QuestScript
{
	protected override void Load()
	{
		SetId(50076);
		SetName("The Past of the Spirits (5)");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_68_MQ040"));
		AddPrerequisite(new LevelPrerequisite(211));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 44310));

		AddDialogHook("EMINENT_68_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_68_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER68_MQ050_startnpc01", "UNDERFORTRESS_68_MQ050", "I will bring the spirits", "Stop! They are in pain!"))
			{
				case 1:
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
			await dialog.Msg("UNDER68_MQ050_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

