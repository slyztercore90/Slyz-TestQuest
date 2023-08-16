//--- Melia Script -----------------------------------------------------------
// Non-existent Book [Linker Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(1078)]
public class Quest1078Script : QuestScript
{
	protected override void Load()
	{
		SetId(1078);
		SetName("Non-existent Book [Linker Advancement] (2)");
		SetDescription("Talk to the Linker Master");
		SetTrack("SProgress", "ESuccess", "JOB_LINKER2_2_TRACK", 3000);

		AddPrerequisite(new CompletedPrerequisite("JOB_LINKER2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_LINKER2_2_select1", "JOB_LINKER2_2", "I'll take the test", "I'm not so sure about it"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			if (character.Inventory.HasItem("Book7", 1))
			{
				character.Inventory.RemoveItem("Book7", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/JOB_LINKER2_1_NPC/archer_buff_skl_Recuperate_circle/1.5/BOT");
				await dialog.Msg("JOB_LINKER2_2_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

