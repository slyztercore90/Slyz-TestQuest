//--- Melia Script -----------------------------------------------------------
// One-Way Street
//--- Description -----------------------------------------------------------
// Quest to Talk to Nikodemas.
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

[QuestScript(90008)]
public class Quest90008Script : QuestScript
{
	protected override void Load()
	{
		SetId(90008);
		SetName("One-Way Street");
		SetDescription("Talk to Nikodemas");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE_83_SQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Rocksodon", new KillObjective(57867, 1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1235));

		AddDialogHook("3CMLAKE_83_PEOPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_PEOPLE5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE_83_SQ_03_DLG_01", "F_3CMLAKE_83_SQ_03", "I'll try to find them", "I have nothing to do there"))
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

