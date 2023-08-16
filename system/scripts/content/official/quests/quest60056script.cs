//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60056)]
public class Quest60056Script : QuestScript
{
	protected override void Load()
	{
		SetId(60056);
		SetName("The Journey to Find Myself (6)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack("SProgress", "ESuccess", "PILGRIM312_SQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_05_1"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Drapeliun", new KillObjective(57861, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM312_SQ_06_01", "PILGRIM312_SQ_06", "Tell him that you will complete it", "I can only help so much"))
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

