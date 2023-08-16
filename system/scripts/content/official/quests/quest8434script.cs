//--- Melia Script -----------------------------------------------------------
// Hidden Place (2)
//--- Description -----------------------------------------------------------
// Quest to Move to the secret location.
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

[QuestScript(8434)]
public class Quest8434Script : QuestScript
{
	protected override void Load()
	{
		SetId(8434);
		SetName("Hidden Place (2)");
		SetDescription("Move to the secret location");
		SetTrack("SProgress", "ESuccess", "ZACHA2F_SQ_02_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ZACHA2F_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Tomb Lord", new KillObjective(57114, 1));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("misc_BRC03_105_1", 1));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("WS_ZACHA2F_01_TO_02", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA2F_SQ02_TREASURE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA2F_SQ_02", "ZACHA2F_SQ_02", "Find the treasure", "Cancel"))
			{
				case 1:
					// Func/ZACHA2F_SQ_02_AGREE;
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

