//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (6)
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

[QuestScript(50349)]
public class Quest50349Script : QuestScript
{
	protected override void Load()
	{
		SetId(50349);
		SetName("In to the Lion's Mouth (6)");
		SetDescription("Talk to Monk Aistis");
		SetTrack("SProgress", "ESuccess", "ABBEY22_4_SQ6_TRACK", "ABBEY22_4_SUBQ6_ARG1");

		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ5"));
		AddPrerequisite(new LevelPrerequisite(354));

		AddObjective("kill0", "Kill 1 Banshee Boss", new KillObjective(103049, 1));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ5_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ6_DEVICE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY22_4_SUBQ6_START1", "ABBEY22_4_SQ6", "It can't be! I'll go save the monks.", "Let's just go past them."))
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
			// Func/ABBEY22_4_SUBQ6_DEVICE_DONE;
			await dialog.Msg("NPCAin/ABBEY22_4_SUBQ6_DEVICE/std/0");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

