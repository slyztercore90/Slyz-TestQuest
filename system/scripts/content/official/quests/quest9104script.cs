//--- Melia Script -----------------------------------------------------------
// The One Who Experienced Death
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(9104)]
public class Quest9104Script : QuestScript
{
	protected override void Load()
	{
		SetId(9104);
		SetName("The One Who Experienced Death");
		SetDescription("Talk to the Paladin Master");
		SetTrack("SProgress", "ESuccess", "CHAPLE_57_6_HQ_01_TRACK_RE", "None");

		AddPrerequisite(new LevelPrerequisite(98));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(59306, 1));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE_57_6_HQ_01_select01", "CHAPLE_57_6_HQ_01", "I will find and defeat Chapparition", "Decline"))
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
			await dialog.Msg("CHAPLE_57_6_HQ_01_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

