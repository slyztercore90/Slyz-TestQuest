//--- Melia Script -----------------------------------------------------------
// Mage Tower in Chaos [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Thaumaturge Submaster.
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

[QuestScript(30104)]
public class Quest30104Script : QuestScript
{
	protected override void Load()
	{
		SetId(30104);
		SetName("Mage Tower in Chaos [Thaumaturge Advancement]");
		SetDescription("Talk to the Thaumaturge Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_THAUMATURGE4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Salamander", new KillObjective(57168, 1));

		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_THAUMATURGE_5_1_select", "JOB_2_THAUMATURGE_5_1", "Ask what you should do", "It's best to face it"))
			{
				case 1:
					await dialog.Msg("JOB_2_THAUMATURGE_5_1_agree");
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_2_THAUMATURGE_5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

