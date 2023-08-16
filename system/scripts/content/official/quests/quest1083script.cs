//--- Melia Script -----------------------------------------------------------
// A Bower's Dream Book [Hunter Advancement] (1)
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

[QuestScript(1083)]
public class Quest1083Script : QuestScript
{
	protected override void Load()
	{
		SetId(1083);
		SetName("A Bower's Dream Book [Hunter Advancement] (1)");
		SetDescription("Talk to the Hunter Master");
		SetTrack("SProgress", "ESuccess", "JOB_HUNTER2_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Lydia Schaffen and the Fletcher", new CollectItemObjective("Book2", 1));
		AddDrop("Book2", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HUNTER2_1_select1", "JOB_HUNTER2_1", "I'll go find the book", "I don't have time for that"))
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
			if (character.Inventory.HasItem("Book2", 1))
			{
				character.Inventory.RemoveItem("Book2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/JOB_HUNTER2_1_NPC/archer_buff_skl_Recuperate_circle/1.5/BOT");
				await dialog.Msg("JOB_HUNTER2_1_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_HUNTER2_2");
	}
}

