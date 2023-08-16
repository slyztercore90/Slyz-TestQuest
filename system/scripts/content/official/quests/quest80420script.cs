//--- Melia Script -----------------------------------------------------------
// The Goddess' Hideout (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Ilona.
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

[QuestScript(80420)]
public class Quest80420Script : QuestScript
{
	protected override void Load()
	{
		SetId(80420);
		SetName("The Goddess' Hideout (2)");
		SetDescription("Talk to Kupole Ilona");
		SetTrack("SPossible", "EPossible", "F_MAPLE_24_1_MQ_02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(411));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23427));

		AddDialogHook("F_MAPLE_241_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("F_MAPLE_24_1_MQ_02_SU");
			dialog.UnHideNPC("F_MAPLE_241_MQ_NPC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

