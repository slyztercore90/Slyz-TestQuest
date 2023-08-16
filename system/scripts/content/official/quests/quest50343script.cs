//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50343)]
public class Quest50343Script : QuestScript
{
	protected override void Load()
	{
		SetId(50343);
		SetName("Narvas Temple's Barrier (9)");
		SetDescription("Talk to Monk Aistis");
		SetTrack("SProgress", "ESuccess", "WTREES22_3_SQ9_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ8"));
		AddPrerequisite(new LevelPrerequisite(351));

		AddDialogHook("WTREES22_3_SUBQ1_NPC5", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WTREES22_3_SUBQ9_START1", "WTREES22_3_SQ9", "Go inside with Monk Aistis.", "Go inside right away."))
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
}

