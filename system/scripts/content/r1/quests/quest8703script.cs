//--- Melia Script -----------------------------------------------------------
// Sword for the People and Shield [Highlander Advancement](3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(8703)]
public class Quest8703Script : QuestScript
{
	protected override void Load()
	{
		SetId(8703);
		SetName("Sword for the People and Shield [Highlander Advancement](3)");
		SetDescription("Talk to Knight Commander Uska");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HIGHLANDER4_3_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_HIGHLANDER4_2"));

		AddObjective("kill0", "Kill 1 Rumor Culprit Bearkaras", new KillObjective(1, MonsterId.Boss_Bearkaras_J1));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HIGHLANDER4_3_01", "JOB_HIGHLANDER4_3", "I'll go to Crystal Mine 2F", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_HIGHLANDER4_3_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_HIGHLANDER4_4");
	}
}

