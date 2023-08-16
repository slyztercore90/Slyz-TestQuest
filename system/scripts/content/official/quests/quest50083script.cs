//--- Melia Script -----------------------------------------------------------
// Eminent's Identity
//--- Description -----------------------------------------------------------
// Quest to Talk to Premier Eminent.
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

[QuestScript(50083)]
public class Quest50083Script : QuestScript
{
	protected override void Load()
	{
		SetId(50083);
		SetName("Eminent's Identity");
		SetDescription("Talk to Premier Eminent");
		SetTrack("SProgress", "ESuccess", "UNDERFORTRESS_69_MQ050_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ040"));
		AddPrerequisite(new LevelPrerequisite(214));

		AddObjective("kill0", "Kill 1 Mandara", new KillObjective(57707, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("EMINENT_69_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDER_69_MQ050_startnpc01", "UNDERFORTRESS_69_MQ050", "Hand over the parts", "Do not hand over the parts"))
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
}

