//--- Melia Script -----------------------------------------------------------
// The gap between King and time
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70846)]
public class Quest70846Script : QuestScript
{
	protected override void Load()
	{
		SetId(70846);
		SetName("The gap between King and time");
		SetDescription("Talk to Indraja");
		SetTrack("SProgress", "ESuccess", "WHITETREES23_3_SQ07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ06"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES233_SQ_07_start1", "WHITETREES23_3_SQ07", "Say that you should go together", "Tell him to wait a bit longer"))
			{
				case 1:
					// Func/SCR_WHITETREES233_SQ_07_F;
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WHITETREES23_3_SQ08");
	}
}

