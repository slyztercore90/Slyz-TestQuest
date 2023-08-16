//--- Melia Script -----------------------------------------------------------
// Missing Herbalist (4)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Old Pile of Boxes.
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

[QuestScript(90181)]
public class Quest90181Script : QuestScript
{
	protected override void Load()
	{
		SetId(90181);
		SetName("Missing Herbalist (4)");
		SetDescription("Investigate the Old Pile of Boxes");
		SetTrack("SProgress", "ESuccess", "LOWLV_GREEN_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_GREEN_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_GREEN_SQ_40_BOX", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_GREEN_AJELI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BalloonText/LOWLV_GREEN_SQ_50_ST/7", "LOWLV_GREEN_SQ_50", "Read the diary.", "Don't read the diary."))
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

