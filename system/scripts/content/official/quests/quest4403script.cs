//--- Melia Script -----------------------------------------------------------
// Trivial Honor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Weiz.
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

[QuestScript(4403)]
public class Quest4403Script : QuestScript
{
	protected override void Load()
	{
		SetId(4403);
		SetName("Trivial Honor (2)");
		SetDescription("Talk to Soldier Weiz");
		SetTrack("SProgress", "ESuccess", "THORN23_Q_13_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_11"));
		AddPrerequisite(new LevelPrerequisite(123));

		AddDialogHook("THORN23_WISE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_WISE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN23_Q_13_select1", "THORN23_Q_13", "I'll burn the Ducky Fat", "It looks dangerous"))
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

		return HookResult.Continue;
	}
}

