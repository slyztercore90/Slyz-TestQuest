//--- Melia Script -----------------------------------------------------------
// The Goddess' Hidden Message
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(80047)]
public class Quest80047Script : QuestScript
{
	protected override void Load()
	{
		SetId(80047);
		SetName("The Goddess' Hidden Message");
		SetDescription("Speak with Goddess Lada");
		SetTrack("SProgress", "ESuccess", "ORCHARD_324_MQ_07_TRACK", "track");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(614275, 614275));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 28800));

		AddDialogHook("ORCHARD324_LADA", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_LADA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_324_MQ_07_start", "ORCHARD_324_MQ_07", "I'll go right away", "Let's wait for a while"))
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

