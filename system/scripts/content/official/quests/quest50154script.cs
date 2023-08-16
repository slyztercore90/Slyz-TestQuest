//--- Melia Script -----------------------------------------------------------
// The Battle
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50154)]
public class Quest50154Script : QuestScript
{
	protected override void Load()
	{
		SetId(50154);
		SetName("The Battle");
		SetDescription("Talk to Assistant Commander Talon");
		SetTrack("SProgress", "ESuccess", "TABLELAND_70_SQ9_TRACK", "boss_a");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ8"));
		AddPrerequisite(new LevelPrerequisite(238));

		AddObjective("kill0", "Kill 1 Centaurus", new KillObjective(103038, 1));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 5));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_70_SQ9_startnpc01", "TABLELAND_70_SQ9", "I'm ready to fight the demons", "I'm not ready yet"))
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
			await dialog.Msg("TABLELAND_70_SQ9_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

