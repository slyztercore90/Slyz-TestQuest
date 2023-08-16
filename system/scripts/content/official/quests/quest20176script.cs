//--- Melia Script -----------------------------------------------------------
// Royal Mausoleum's Secret Location
//--- Description -----------------------------------------------------------
// Quest to Go to Royal Mausoleum's secret location.
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

[QuestScript(20176)]
public class Quest20176Script : QuestScript
{
	protected override void Load()
	{
		SetId(20176);
		SetName("Royal Mausoleum's Secret Location");
		SetDescription("Go to Royal Mausoleum's secret location");

		AddPrerequisite(new CompletedPrerequisite("ROKAS28_QM1"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddReward(new ItemReward("misc_gemExpStone01", 1));

		AddDialogHook("ROKAS28_SECRET_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA32_DEVICE_1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("NPCAin/ZACHA32_DEVICE_1_2/ON/1");
			await dialog.Msg("EffectLocalNPC/ZACHA32_DEVICE_1_2/F_light003_green/3/MID");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

