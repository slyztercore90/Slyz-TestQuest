//--- Melia Script -----------------------------------------------------------
// Collecting Evil Spirits [Sorcerer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sorcerer Master.
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

[QuestScript(17670)]
public class Quest17670Script : QuestScript
{
	protected override void Load()
	{
		SetId(17670);
		SetName("Collecting Evil Spirits [Sorcerer Advancement]");
		SetDescription("Talk to the Sorcerer Master");
		SetTrack("SProgress", "ESuccess", "JOB_SORCERER4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Devilglove", new KillObjective(57170, 1));

		AddDialogHook("JOB_SORCERER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SORCERER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_SORCERER4_1_ST", "JOB_SORCERER4_1", "I will defeat the Devilglove", "I will come back later"))
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
			await dialog.Msg("JOB_SORCERER4_1_COMP");
			dialog.ShowHelp("TUTO_CLASS_SOCERER");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

