//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Inesa Hamondale.
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

[QuestScript(60086)]
public class Quest60086Script : QuestScript
{
	protected override void Load()
	{
		SetId(60086);
		SetName("The Missing Bishop (2)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ1_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("Scroll_Warp_quest", 10));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_TOOL_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORSHA_MQ1_02_01", "ORSHA_MQ1_02", "Alright", "I don't think that'll be needed"))
			{
				case 1:
					await dialog.Msg("ORSHA_MQ1_02_01_01");
					dialog.AddonMessage("NOTICE_Dm_Scroll", "Worship the Statue of Goddess Ausrine in the Central Plaza!", 8);
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

