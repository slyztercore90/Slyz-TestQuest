//--- Melia Script -----------------------------------------------------------
// Imminent Danger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Ulysses.
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

[QuestScript(60092)]
public class Quest60092Script : QuestScript
{
	protected override void Load()
	{
		SetId(60092);
		SetName("Imminent Danger (1)");
		SetDescription("Talk with Chaser Ulysses");
		SetTrack("SProgress", "ESuccess", "SIAU15RE_MQ_05_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Minotaur", new KillObjective(57995, 1));

		AddReward(new ExpReward(7500, 7500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("SIAU15RE_MQ_05_ITEM", 1));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_YEULIS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAU15RE_MQ_05_ITEM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAU15RE_MQ_05_01", "SIAU15RE_MQ_05", "I will check it", "I'll follow Pranas"))
			{
				case 1:
					dialog.HideNPC("SIAU15RE_MQ_05_ITEM");
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

