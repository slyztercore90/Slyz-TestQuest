//--- Melia Script -----------------------------------------------------------
// Honey-eating Biteregina
//--- Description -----------------------------------------------------------
// Quest to Check the mead storage boxes.
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

[QuestScript(16110)]
public class Quest16110Script : QuestScript
{
	protected override void Load()
	{
		SetId(16110);
		SetName("Honey-eating Biteregina");
		SetDescription("Check the mead storage boxes");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_46_4_SQ_02_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(57285, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MEADBOX", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

