//--- Melia Script -----------------------------------------------------------
// Magic Association Collection Request
//--- Description -----------------------------------------------------------
// Quest to Check the Stone of Requests.
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

[QuestScript(5)]
public class Quest5Script : QuestScript
{
	protected override void Load()
	{
		SetId(5);
		SetName("Magic Association Collection Request");
		SetDescription("Check the Stone of Requests");

		AddDialogHook("DROPITEM_COLLECTINGQUEST_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("COLLECTION_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DROPITEM_COLLECTINGQUEST_dlg1", "DROPITEM_COLLECTINGQUEST", "Looking forward to cooperate.", "I don't think I can help."))
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
			await dialog.Msg("DROPITEM_COLLECTINGQUEST_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

