//--- Melia Script -----------------------------------------------------------
// Kartas Appears (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Medeina.
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

[QuestScript(80425)]
public class Quest80425Script : QuestScript
{
	protected override void Load()
	{
		SetId(80425);
		SetName("Kartas Appears (1)");
		SetDescription("Talk to Goddess Medeina");
		SetTrack("SPossible", "ESuccess", "F_MAPLE_24_1_MQ_05_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(411));
		AddPrerequisite(new ItemPrerequisite("F_MAPLE_242_MQ_04_2_ITEM", -100));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23427));

		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_06_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_MAPLE_24_1_MQ_05_ST", "F_MAPLE_24_1_MQ_05", "Here, the Seed of the Divine Tree.", "I can't give you the seed."))
			{
				case 1:
					dialog.HideNPC("F_MAPLE_241_MQ_MEDEINA_NPC");
					dialog.HideNPC("F_MAPLE_241_MQ_NPC1");
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
			await dialog.Msg("F_MAPLE_24_1_MQ_05_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

