//--- Melia Script -----------------------------------------------------------
// The Road to Klaipeda (2)
//--- Description -----------------------------------------------------------
// Quest to Go to Klaipeda.
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

[QuestScript(1019)]
public class Quest1019Script : QuestScript
{
	protected override void Load()
	{
		SetId(1019);
		SetName("The Road to Klaipeda (2)");
		SetDescription("Go to Klaipeda");
		SetTrack("SProgress", "ESuccess", "SIAUL_WEST_WOOD_SPIRIT_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_LAIMONAS4"));
		AddPrerequisite(new LevelPrerequisite(4));

		AddObjective("kill0", "Kill 1 Rocktortuga", new KillObjective(41233, 1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 728));

		AddDialogHook("SIAUL_ST1_ST2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_ST1_ST2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAUL_WEST_WOOD_SPIRIT_ST", "SIAUL_WEST_WOOD_SPIRIT", "I'll lend my strength to you", "Enter Klaipeda"))
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
			dialog.UnHideNPC("JOB_HOPLITE2_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

