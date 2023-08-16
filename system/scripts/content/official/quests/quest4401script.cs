//--- Melia Script -----------------------------------------------------------
// Trivial Honor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Weiz.
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

[QuestScript(4401)]
public class Quest4401Script : QuestScript
{
	protected override void Load()
	{
		SetId(4401);
		SetName("Trivial Honor (1)");
		SetDescription("Talk to Soldier Weiz");

		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_12"));
		AddPrerequisite(new LevelPrerequisite(123));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_WISE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_WISE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN23_Q_11_select1", "THORN23_Q_11", "I'll gather Ducky Fat", "I'm not a new recruit so I'll refuse"))
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
			if (character.Inventory.HasItem("THORN23_Q_11_ITEM", 5))
			{
				character.Inventory.RemoveItem("THORN23_Q_11_ITEM", 5);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("THORN23_Q_11_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

