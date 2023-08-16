//--- Melia Script -----------------------------------------------------------
// Liberation of Magic (3)
//--- Description -----------------------------------------------------------
// Quest to Read the manual for the Regulator again.
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

[QuestScript(8432)]
public class Quest8432Script : QuestScript
{
	protected override void Load()
	{
		SetId(8432);
		SetName("Liberation of Magic (3)");
		SetDescription("Read the manual for the Regulator again");
		SetTrack("SProgress", "ESuccess", "ZACHA1F_SQ_05_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ZACHA1F_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(83));

		AddObjective("kill0", "Kill 1 Royal Mausoleum Cube", new KillObjective(47261, 1));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1660));

		AddDialogHook("ZACHA1F_SQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA1F_SQ_05_ST", "ZACHA1F_SQ_05", "Go to destroy the last regulator", "I'll wait a little bit"))
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

