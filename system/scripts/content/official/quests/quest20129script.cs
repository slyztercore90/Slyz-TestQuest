//--- Melia Script -----------------------------------------------------------
// Lens of the Stars [Quarrel Shooter Advancement]
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

[QuestScript(20129)]
public class Quest20129Script : QuestScript
{
	protected override void Load()
	{
		SetId(20129);
		SetName("Lens of the Stars [Quarrel Shooter Advancement]");
		SetDescription("Talk to the Quarrel Shooter Master");
		SetTrack("SProgress", "ESuccess", "JOB_QUARRELSHOOTER1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 1 Astral Tower Lens", new CollectItemObjective("JOB_QUARRELSHOOTER1_Lens", 1));
		AddDrop("JOB_QUARRELSHOOTER1_Lens", 10f, "boss_ShadowGaoler_J1");

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(57158, 1));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_QUARRELSHOOTER1_select1", "JOB_QUARRELSHOOTER1", "I'll do you this favor", "Sounds suspicious, I'll have to decline"))
			{
				case 1:
					await dialog.Msg("JOB_QUARRELSHOOTER1_AG");
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
			if (character.Inventory.HasItem("JOB_QUARRELSHOOTER1_Lens", 1))
			{
				character.Inventory.RemoveItem("JOB_QUARRELSHOOTER1_Lens", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_QUARRELSHOOTER1_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

