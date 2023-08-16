//--- Melia Script -----------------------------------------------------------
// Release Goddess Saule (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(18001)]
public class Quest18001Script : QuestScript
{
	protected override void Load()
	{
		SetId(18001);
		SetName("Release Goddess Saule (1)");
		SetDescription("Talk to Goddess Saule");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ02"));
		AddPrerequisite(new LevelPrerequisite(55));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("HUEVILLAGE_58_4_MQ01_select", "HUEVILLAGE_58_4_MQ01", "I'll destroy it", "I need more time to prepare"))
			{
				case 1:
					await dialog.Msg("HUEVILLAGE_58_4_MQ01_agree");
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
		character.Quests.Start("HUEVILLAGE_58_4_MQ05");
	}
}

