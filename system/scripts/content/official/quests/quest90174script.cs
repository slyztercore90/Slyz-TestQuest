//--- Melia Script -----------------------------------------------------------
// It's A Trap
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(90174)]
public class Quest90174Script : QuestScript
{
	protected override void Load()
	{
		SetId(90174);
		SetName("It's A Trap");
		SetDescription("Talk to the Linker Master");
		SetTrack("SProgress", "ESuccess", "LOWLV_EYEOFBAIGA_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(290));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_EYEOFBAIGA_SQ_50", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LOWLV_EYEOFBAIGA_SQ_50_ST", "LOWLV_EYEOFBAIGA_SQ_50", "How do I follow the trail?", "Good work."))
			{
				case 1:
					await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_50_AG");
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

