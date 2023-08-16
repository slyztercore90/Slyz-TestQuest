//--- Melia Script -----------------------------------------------------------
// Sacred Tree of the Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guide Owl Sculpture.
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

[QuestScript(30061)]
public class Quest30061Script : QuestScript
{
	protected override void Load()
	{
		SetId(30061);
		SetName("Sacred Tree of the Forest (1)");
		SetDescription("Talk to the Guide Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_12_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_12_MQ_02_select", "KATYN_12_MQ_02", "Show the crystal formed by the energy from Karolis Springs", "I don't think it can be helped"))
			{
				case 1:
					await dialog.Msg("KATYN_12_MQ_02_agree");
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

		return HookResult.Continue;
	}
}

