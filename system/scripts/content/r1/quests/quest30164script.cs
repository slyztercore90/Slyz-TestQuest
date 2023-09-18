//--- Melia Script -----------------------------------------------------------
// Who am I(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Spirit at the Solitary Cells.
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

[QuestScript(30164)]
public class Quest30164Script : QuestScript
{
	protected override void Load()
	{
		SetId(30164);
		SetName("Who am I(1)");
		SetDescription("Talk to Zanas' Spirit at the Solitary Cells");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_10"));

		AddObjective("kill0", "Kill 17 Red Socket Mage(s)", new KillObjective(17, MonsterId.Socket_Mage_Red));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_OBJ_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_80_MQ_1_select", "PRISON_80_MQ_1", "Say that you think it is a good idea", "Say that they will never fall for that"))
		{
			case 1:
				await dialog.Msg("PRISON_80_MQ_1_agree");
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PRISON_80_MQ_2");
	}
}

