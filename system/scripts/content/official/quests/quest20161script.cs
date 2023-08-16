//--- Melia Script -----------------------------------------------------------
// Sculptor Hilda's Data (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Hilda.
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

[QuestScript(20161)]
public class Quest20161Script : QuestScript
{
	protected override void Load()
	{
		SetId(20161);
		SetName("Sculptor Hilda's Data (1)");
		SetDescription("Talk to Sculptor Hilda");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ROKAS25_HILDA1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_HILDA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS25_SQ_06_select_01", "ROKAS25_SQ_06", "I'll let you know when I see it", "Decline"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ROKAS25_SQ_06_succ01");
			await dialog.Msg("EffectLocalNPC/ROKAS25_HILDA1/F_pc_warp_circle/1/BOT");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("ROKAS25_HILDA1");
			dialog.UnHideNPC("ROKAS25_HILDA2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

