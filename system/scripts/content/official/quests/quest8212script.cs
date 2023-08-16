//--- Melia Script -----------------------------------------------------------
// Destroying the Guardian Device
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8212)]
public class Quest8212Script : QuestScript
{
	protected override void Load()
	{
		SetId(8212);
		SetName("Destroying the Guardian Device");
		SetDescription("Read the epitaph");
		SetTrack("SProgress", "ESuccess", "ZACHA1F_MQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(81));

		AddObjective("kill0", "Kill 2 Royal Mausoleum Stone Lantern(s)", new KillObjective(47253, 2));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA1F_MQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA1F_MQ_03_01", "ZACHA1F_MQ_03", "Destroy the corrupted protecting device", "I'll wait a little bit"))
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

