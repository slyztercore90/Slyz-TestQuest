//--- Melia Script -----------------------------------------------------------
// Preparation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50082)]
public class Quest50082Script : QuestScript
{
	protected override void Load()
	{
		SetId(50082);
		SetName("Preparation (2)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ030"));
		AddPrerequisite(new LevelPrerequisite(214));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("AMANDA_69_2", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER69_MQ4_DEVICE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_69_MQ040_startnpc01", "UNDERFORTRESS_69_MQ040", "Destroy the totems? Got it", "We need to find another way"))
			{
				case 1:
					await dialog.Msg("UNDER_69_MQ040_startnpc02");
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
			await dialog.Msg("FadeOutIN/1000");
			dialog.AddonMessage("NOTICE_Dm_Clear", "The magic circle is activating!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

