//--- Melia Script -----------------------------------------------------------
// Kruvina and the Revelators
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70424)]
public class Quest70424Script : QuestScript
{
	protected override void Load()
	{
		SetId(70424);
		SetName("Kruvina and the Revelators");
		SetDescription("Talk to Mage Melchioras");
		SetTrack("SProgress", "ESuccess", "SCR_CASTLE652_MQ_05_TRACKSTART", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CASTLE652_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_01_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE652_MQ_05_start", "CASTLE65_2_MQ05", "Quick, follow me", "Please wait a while"))
			{
				case 1:
					// Func/SCR_CASTLE652_MQ_05_TURN;
					await dialog.Msg("CASTLE652_MQ_05_agree1");
					// Func/SCR_CASTLE652_MQ_05_MOVE;
					await dialog.Msg("CASTLE652_MQ_05_agree2");
					// Func/SCR_CASTLE652_MQ_05_M;
					await dialog.Msg("FadeOutIN/1000");
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

