//--- Melia Script -----------------------------------------------------------
// A Sword and Shield for the People (3)
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

[QuestScript(72142)]
public class Quest72142Script : QuestScript
{
	protected override void Load()
	{
		SetId(72142);
		SetName("A Sword and Shield for the People (3)");
		SetDescription("Talk to Knight Commander Uska");
		SetTrack("SProgress", "ESuccess", "MASTER_HIGHLANDER2_3_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("MASTER_HIGHLANDER2_2"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Rumor Culprit Bearkaras", new KillObjective(57156, 1));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_HIGHLANDER2_3_DLG1", "MASTER_HIGHLANDER2_3", "I'll go to Crystal Mine 2F", "Decline"))
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
			await dialog.Msg("MASTER_HIGHLANDER2_3_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_HIGHLANDER2_4");
	}
}

