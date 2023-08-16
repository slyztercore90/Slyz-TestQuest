//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita at Fedimian Suburbs.
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

[QuestScript(8472)]
public class Quest8472Script : QuestScript
{
	protected override void Load()
	{
		SetId(8472);
		SetName("Goddess Gabija (2)");
		SetDescription("Talk to Grita at Fedimian Suburbs");

		AddPrerequisite(new CompletedPrerequisite("TO_THE_TOWER_01"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("REMAINS40_GRITA", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_GRITA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TO_THE_TOWER_02_01", "TO_THE_TOWER_02", "Follow Grita to the Mage Tower", "About Goddess Gabija", "Reject"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("TO_THE_TOWER_02_AG");
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
			dialog.HideNPC("REMAINS40_GRITA");
			await dialog.Msg("FadeOutIN/500");
			dialog.UnHideNPC("FTOWER41_GRITA_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

