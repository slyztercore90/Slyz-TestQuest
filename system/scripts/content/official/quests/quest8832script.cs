//--- Melia Script -----------------------------------------------------------
// Great Escape Portal (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Sabina.
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

[QuestScript(8832)]
public class Quest8832Script : QuestScript
{
	protected override void Load()
	{
		SetId(8832);
		SetName("Great Escape Portal (3)");
		SetDescription("Talk to Chronomancer Sabina");
		SetTrack("SProgress", "ESuccess", "FLASH61_SQ_11_1_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("FLASH61_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(190));

		AddObjective("kill0", "Kill 1 Lepus", new KillObjective(57303, 1));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 47120));

		AddDialogHook("FLASH61_SABINA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_SABINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH61_SQ_11_01", "FLASH61_SQ_11", "I'm ready", "Wait for a while"))
			{
				case 1:
					await dialog.Msg("FLASH61_SQ_11_02");
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
			await dialog.Msg("FLASH61_SQ_11_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

