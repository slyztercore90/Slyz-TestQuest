//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60119)]
public class Quest60119Script : QuestScript
{
	protected override void Load()
	{
		SetId(60119);
		SetName("Bishop Urbonas' Whereabouts (4)");
		SetDescription("Talk with Priest Pranas");
		SetTrack("SProgress", "ESuccess", "PRISON621_MQ_05_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Clymen", new KillObjective(57999, 1));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_URBONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON621_MQ_03_02", "PRISON621_MQ_05", "I will check it", "Is there no other way?"))
			{
				case 1:
					await dialog.Msg("PRISON621_MQ_03_02_AG");
					dialog.UnHideNPC("PRISON621_TO_PRISON621_1");
					dialog.AddonMessage("NOTICE_Dm_Scroll", "Check the map of the Ashaq Underground Prison 1F in your inventory!", 5);
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

