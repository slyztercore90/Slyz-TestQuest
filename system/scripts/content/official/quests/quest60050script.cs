//--- Melia Script -----------------------------------------------------------
// A Dead End (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Alina.
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

[QuestScript(60050)]
public class Quest60050Script : QuestScript
{
	protected override void Load()
	{
		SetId(60050);
		SetName("A Dead End (4)");
		SetDescription("Talk with Member Alina");
		SetTrack("SProgress", "ESuccess", "PILGRIM311_SQ_08_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Chaser Werewolf", new KillObjective(57860, 1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_ALINA_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_IRMANTAS_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM311_SQ_08_01", "PILGRIM311_SQ_08", "We're almost there. Cheer up. ", "Let's rest a bit more"))
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

