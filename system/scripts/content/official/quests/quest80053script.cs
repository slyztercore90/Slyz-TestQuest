//--- Melia Script -----------------------------------------------------------
// Stare of the distrust
//--- Description -----------------------------------------------------------
// Quest to Talk with Necromancer Lemija.
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

[QuestScript(80053)]
public class Quest80053Script : QuestScript
{
	protected override void Load()
	{
		SetId(80053);
		SetName("Stare of the distrust");
		SetDescription("Talk with Necromancer Lemija");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(208));

		AddDialogHook("TABLELAND_11_1_LEMIJA", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_SQ_02_ENDNPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_11_1_SQ_02_start", "TABLELAND_11_1_SQ_02", "Let's go together", "My hands are tied at the moment."))
			{
				case 1:
					dialog.HideNPC("TABLELAND_11_1_LEMIJA");
					// Func/TABLELAND_11_1_SQ_02_NPC;
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
			await dialog.Msg("TABLELAND_11_1_SQ_02_succ");
			// Func/TABLELAND_11_1_SQ_02_END;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TABLELAND_11_1_SQ_03");
	}
}

