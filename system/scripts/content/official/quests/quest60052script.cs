//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (1)
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

[QuestScript(60052)]
public class Quest60052Script : QuestScript
{
	protected override void Load()
	{
		SetId(60052);
		SetName("The Journey to Find Myself (1)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack("SProgress", "ESuccess", "PILGRIM312_SQ_02_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Desmodus(s)", new KillObjective(58147, 6));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM312_SQ_02_01", "PILGRIM312_SQ_02", "Tell him that you will feed him the detoxifying herb", "Look little more"))
			{
				case 1:
					// Func/PILGRIM312_SQ_02_01_ADD;
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

