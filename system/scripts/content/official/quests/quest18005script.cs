//--- Melia Script -----------------------------------------------------------
// Release Goddess Saule (2)
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

[QuestScript(18005)]
public class Quest18005Script : QuestScript
{
	protected override void Load()
	{
		SetId(18005);
		SetName("Release Goddess Saule (2)");
		SetDescription("Talk to Goddess Saule");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ01"));
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
			switch (await dialog.Select("HUEVILLAGE_58_4_MQ05_select", "HUEVILLAGE_58_4_MQ05", "What should I do?", "Wait until my strength is fully recovered"))
			{
				case 1:
					await dialog.Msg("HUEVILLAGE_58_4_MQ05_agree");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC01");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC02");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC03");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC04");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC05");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC06");
					dialog.UnHideNPC("HUEVILLAGE_58_4_MQ05_NPC07");
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
			await dialog.Msg("HUEVILLAGE_58_4_MQ05_succ");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC01");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC02");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC03");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC04");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC05");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC06");
			dialog.HideNPC("HUEVILLAGE_58_4_MQ05_NPC07");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_4_MQ06");
	}
}

