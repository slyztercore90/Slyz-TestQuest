//--- Melia Script -----------------------------------------------------------
// Wall of Sword and Shield [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Look for the Rodelero Submaster .
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

[QuestScript(8710)]
public class Quest8710Script : QuestScript
{
	protected override void Load()
	{
		SetId(8710);
		SetName("Wall of Sword and Shield [Rodelero Advancement]");
		SetDescription("Look for the Rodelero Submaster ");
		SetTrack("SProgress", "ESuccess", "JOB_RODELERO4_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Rodelero Submaster", new KillObjective(103029, 1));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_RODELERO4_1_01", "JOB_RODELERO4_1", "Accept the duel with the Master", "Avoid the duel"))
			{
				case 1:
					await dialog.Msg("JOB_RODELERO4_1_02");
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
			await dialog.Msg("JOB_RODELERO4_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

