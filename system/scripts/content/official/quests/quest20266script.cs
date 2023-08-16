//--- Melia Script -----------------------------------------------------------
// Unexpected Research
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Simas.
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

[QuestScript(20266)]
public class Quest20266Script : QuestScript
{
	protected override void Load()
	{
		SetId(20266);
		SetName("Unexpected Research");
		SetDescription("Talk to Believer Simas");
		SetTrack("SProgress", "ESuccess", "THORN20_MQ06_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 1 Demon Summoning Crystal", new KillObjective(153029, 1));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MAGIC3STAGE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN20_MAGIC3STAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN20_MQ06_select01", "THORN20_MQ06", "Leave it to me", "I don't want to be part of a weird research"))
			{
				case 1:
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
			dialog.UnHideNPC("THORN_MQ06MAGIC_UNHIDE");
			await dialog.Msg("THORN20_MQ06_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

