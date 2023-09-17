//--- Melia Script -----------------------------------------------------------
// Insatiable Hunger (4)
//--- Description -----------------------------------------------------------
// Quest to Make a grave for Pilgrim Liliya.
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

[QuestScript(19461)]
public class Quest19461Script : QuestScript
{
	protected override void Load()
	{
		SetId(19461);
		SetName("Insatiable Hunger (4)");
		SetDescription("Make a grave for Pilgrim Liliya");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_030"));

		AddDialogHook("PILGRIM46_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_031_ST", "PILGRIM46_SQ_031", "Keep listening to him", "Leave"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_031_AC");
				await dialog.Msg("EffectLocalNPC/PILGRIM46_NPC01/I_spread_out001_light_violet2/1/BOT");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "Liliya passed away. {nl}Make a grave for her.", 5);
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

		dialog.HideNPC("PILGRIM46_NPC01");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("PILGRIM46_TOMB");
		await dialog.Msg("EffectLocalNPC/PILGRIM46_TOMB/F_cleric_flins_spread_out/5/BOT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Made a grave for Liliya");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

