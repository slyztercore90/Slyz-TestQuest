//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (6)
//--- Description -----------------------------------------------------------
// Quest to Find Agailla Flurry's gravestones .
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

[QuestScript(20219)]
public class Quest20219Script : QuestScript
{
	protected override void Load()
	{
		SetId(20219);
		SetName("Flurry's Epitaphs (6)");
		SetDescription("Find Agailla Flurry's gravestones ");
		SetTrack("SProgress", "ESuccess", "REMAINS39_MQ07_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ06"));
		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(47317, 1));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("misc_liena_pants_2", 1));
		AddReward(new ItemReward("Vis", 37080));

		AddDialogHook("REMAINS39_MQ_MONUMENT6", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_MQ_MONUMENT6", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAINS39_MQ07_succ01");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You've read all of Agailla Flurry's epitaphs{nl}Your status has increased by 1!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

