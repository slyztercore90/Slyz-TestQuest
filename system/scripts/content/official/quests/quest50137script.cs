//--- Melia Script -----------------------------------------------------------
// Rescue Rose (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas nearby the Medie State Apartments.
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

[QuestScript(50137)]
public class Quest50137Script : QuestScript
{
	protected override void Load()
	{
		SetId(50137);
		SetName("Rescue Rose (4)");
		SetDescription("Talk to Edmundas nearby the Medie State Apartments");
		SetTrack("SProgress", "ESuccess", "ABBAY_64_3_MQ040_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ030"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Deathweaver", new KillObjective(41380, 1));

		AddReward(new ExpReward(211050, 211050));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("ABBEY643_EDMONDA03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY_64_3_MQ040_startnpc01", "ABBAY_64_3_MQ040", "I'll rescue Rose", "Ask her to wait a bit"))
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

