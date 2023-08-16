//--- Melia Script -----------------------------------------------------------
// Tools and Creations [Dievdirbys Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the blacksmith at Orsha.
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

[QuestScript(70318)]
public class Quest70318Script : QuestScript
{
	protected override void Load()
	{
		SetId(70318);
		SetName("Tools and Creations [Dievdirbys Advancement] (3)");
		SetDescription("Talk to the blacksmith at Orsha");

		AddPrerequisite(new CompletedPrerequisite("JOB_2_DIEVDIRBYS3_2"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORSHA_BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_DIEVDIRBYS3_3_1", "JOB_2_DIEVDIRBYS3_3", "I will bring it", "Do you need something delivered?"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/ORSHA_BLACKSMITH/F_light048_yellow/1/MID");
					await dialog.Msg("JOB_2_DIEVDIRBYS3_3_2");
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

