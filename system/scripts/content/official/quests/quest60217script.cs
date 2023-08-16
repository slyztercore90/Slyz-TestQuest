//--- Melia Script -----------------------------------------------------------
// Alembique Tales(8)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Celvica.
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

[QuestScript(60217)]
public class Quest60217Script : QuestScript
{
	protected override void Load()
	{
		SetId(60217);
		SetName("Alembique Tales(8)");
		SetDescription("Talk with Priest Celvica");

		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(320));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LSCAVE551_SQ_9_1", "LSCAVE551_SQ_9", "Alright", "Calm down"))
			{
				case 1:
					await dialog.Msg("FadeOutIN/1500");
					await Task.Delay(800);
					dialog.HideNPC("LSCAVE551_CELVERKA_NPC");
					dialog.UnHideNPC("LSCAVE551_ALTAR_NPC");
					dialog.AddonMessage("NOTICE_Dm_Clear", "Priest Celvica has left to find Kedora Alliance Merchant Alta.{nl}Find Alta before something happens.");
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
			await dialog.Msg("LSCAVE551_SQ_9_3_1");
			await dialog.Msg("FadeOutIN/1800");
			await Task.Delay(500);
			// Func/LSCAVE551_SQ_9_AFTER_MAKE;
			await Task.Delay(14000);
			await dialog.Msg("FadeOutIN/1800");
			await dialog.Msg("LSCAVE551_SQ_9_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

