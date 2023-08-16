//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Urbonas.
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

[QuestScript(60121)]
public class Quest60121Script : QuestScript
{
	protected override void Load()
	{
		SetId(60121);
		SetName("Bishop Urbonas' Whereabouts (6)");
		SetDescription("Talk to Bishop Urbonas");

		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Blue Dumaro(s) or Blue Wendigo(s) or Yekubite(s) or Blue Vubbe Miner(s)", new KillObjective(8, 57991, 58002, 58094, 11127));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Drug_SP1_Q", 20));
		AddReward(new ItemReward("Vis", 2210));

		AddDialogHook("PRISON621_URBONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON621_MQ_07_01", "PRISON621_MQ_07", "Leave it to me", "That's a little too much for me"))
			{
				case 1:
					await dialog.Msg("PRISON621_MQ_07_01_AG");
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PRISON621_MQ_04");
	}
}

