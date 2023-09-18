//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 2 [Quarrel Shooter Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Master.
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

[QuestScript(1087)]
public class Quest1087Script : QuestScript
{
	protected override void Load()
	{
		SetId(1087);
		SetName("Dream Book of the Bow 2 [Quarrel Shooter Advancement] (1)");
		SetDescription("Talk to the Quarrel Shooter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Lydia Schaffen Crossroads", new CollectItemObjective("Book4", 1));
		AddDrop("Book4", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL2_1_select1", "JOB_QUARREL2_1", "I'll go find the book", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_QUARREL2_1_prog1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("Book4", 1))
		{
			character.Inventory.RemoveItem("Book4", 1);
			await dialog.Msg("EffectLocalNPC/MASTER_QU/archer_buff_skl_Recuperate_circle/1.5/BOT");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_QUARREL2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_QUARREL2_2");
	}
}

