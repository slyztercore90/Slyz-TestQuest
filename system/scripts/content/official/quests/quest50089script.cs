//--- Melia Script -----------------------------------------------------------
// Doubt
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

[QuestScript(50089)]
public class Quest50089Script : QuestScript
{
	protected override void Load()
	{
		SetId(50089);
		SetName("Doubt");
		SetDescription("Talk to Grave Robber Amanda");
		SetTrack("SProgress", "ESuccess", "UNDERFORTRESS_68_MQ070_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_68_MQ060"));
		AddPrerequisite(new LevelPrerequisite(211));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));

		AddDialogHook("AMANDA_68_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_68_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_68_MQ070_startnpc01", "UNDERFORTRESS_68_MQ070", "But that's absurd!", "About other suspicious things", "Ignore"))
			{
				case 1:
					await dialog.Msg("UNDER_68_MQ070_startnpc_prog01");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("UNDER_68_MQ070_startnpc01_add");
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
			await dialog.Msg("UNDER_68_MQ070_succ01");
			dialog.UnHideNPC("AMANDA_69_1");
			dialog.UnHideNPC("EMINENT_69_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

