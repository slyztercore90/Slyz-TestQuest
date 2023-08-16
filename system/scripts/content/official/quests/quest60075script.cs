//--- Melia Script -----------------------------------------------------------
// Orsha (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Officer Lutas.
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

[QuestScript(60075)]
public class Quest60075Script : QuestScript
{
	protected override void Load()
	{
		SetId(60075);
		SetName("Orsha (2)");
		SetDescription("Talk with Officer Lutas");
		SetTrack("SProgress", "ESuccess", "SIAU16_MQ_06_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Poata", new KillObjective(57993, 1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI16_LUTAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_LUTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU16_MQ_06_01", "SIAU16_MQ_06", "I'll wait", "Tell me about the procedure", "I have some complaints"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("SIAU16_MQ_06_01_add");
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

