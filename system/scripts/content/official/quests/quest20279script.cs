//--- Melia Script -----------------------------------------------------------
// Activate the Obelisk (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Village Priest.
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

[QuestScript(20279)]
public class Quest20279Script : QuestScript
{
	protected override void Load()
	{
		SetId(20279);
		SetName("Activate the Obelisk (3)");
		SetDescription("Talk to the Village Priest");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ03"));
		AddPrerequisite(new LevelPrerequisite(49));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 5145));

		AddDialogHook("HUEVILLAGE_58_2_MQ02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_2_MQ02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("HUEVILLAGE_58_2_MQ04_select01", "HUEVILLAGE_58_2_MQ04", "Ask where the Obelisk is located", "About God", "Restore it yourself"))
			{
				case 1:
					await dialog.Msg("HUEVILLAGE_58_2_MQ04_select01_Q");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("HUEVILLAGE_58_2_MQ04_add");
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
			await dialog.Msg("HUEVILLAGE_58_2_MQ04_startnpc_succ");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Find the Andale Village Priest at Cobalt Forest!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

