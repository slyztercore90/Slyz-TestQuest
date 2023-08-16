//--- Melia Script -----------------------------------------------------------
// Prison Scout
//--- Description -----------------------------------------------------------
// Quest to Investigate the Red Energy.
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

[QuestScript(30040)]
public class Quest30040Script : QuestScript
{
	protected override void Load()
	{
		SetId(30040);
		SetName("Prison Scout");
		SetDescription("Investigate the Red Energy");
		SetTrack("SProgress", "ESuccess", "d_prison_62_3_kerberos", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Cerberus", new KillObjective(58252, 1));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_SQ_04_OBJ", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

