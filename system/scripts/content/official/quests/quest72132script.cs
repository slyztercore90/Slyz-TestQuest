//--- Melia Script -----------------------------------------------------------
// The Dream Bow Book (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Master.
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

[QuestScript(72132)]
public class Quest72132Script : QuestScript
{
	protected override void Load()
	{
		SetId(72132);
		SetName("The Dream Bow Book (1)");
		SetDescription("Talk to the Hunter Master");
		SetTrack("SProgress", "ESuccess", "JOB_HUNTER2_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Lydia Schaffen and the Fletcher", new CollectItemObjective("MASTER_HUNTER1_1_ITEM", 1));
		AddDrop("MASTER_HUNTER1_1_ITEM", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_HUNTER1_1_DLG1", "MASTER_HUNTER1_1", "Alright, I'll help you", "I don't have time for that"))
			{
				case 1:
					await dialog.Msg("JOB_HUNTER2_1_prog1");
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
			if (character.Inventory.HasItem("MASTER_HUNTER1_1_ITEM", 1))
			{
				character.Inventory.RemoveItem("MASTER_HUNTER1_1_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/JOB_HUNTER2_1_NPC/archer_buff_skl_Recuperate_circle/1.5/BOT");
				await dialog.Msg("MASTER_HUNTER1_1_DLG2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_HUNTER1_2");
	}
}

