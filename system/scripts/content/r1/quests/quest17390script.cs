//--- Melia Script -----------------------------------------------------------
// Still Needs Memory [Bokor Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Get the jewel from the Krivis Master.
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

[QuestScript(17390)]
public class Quest17390Script : QuestScript
{
	protected override void Load()
	{
		SetId(17390);
		SetName("Still Needs Memory [Bokor Advancement] (2)");
		SetDescription("Get the jewel from the Krivis Master");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("JOB_BOCOR4_1"));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BOCOR4_2_ST", "JOB_BOCOR4_2", "I will go back to the Bokor Master", "I'll stop now, I'm too afraid"))
		{
			case 1:
				await dialog.Msg("JOB_BOCOR4_2_AC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_BOCOR4_2_COMP1");
		await Task.Delay(1000);
		await dialog.Msg("CameraShockWaveLocal/2/99999/10/10/100/30");
		await dialog.Msg("EffectLocalNPC/MASTER_BOCORS/F_pc_warp_circle/1/BOT");
		await Task.Delay(1000);
		await dialog.Msg("EffectLocalNPC/MASTER_BOCORS/I_cleric_devinestigma_force_dark/2/MID");
		await Task.Delay(1000);
		await dialog.Msg("JOB_BOCOR4_2_COMP2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_BOCOR4_3");
	}
}

