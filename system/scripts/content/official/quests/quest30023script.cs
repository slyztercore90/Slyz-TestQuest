//--- Melia Script -----------------------------------------------------------
// One Step Closer to Freedom
//--- Description -----------------------------------------------------------
// Quest to Talk with the Rimos' Spirit.
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

[QuestScript(30023)]
public class Quest30023Script : QuestScript
{
	protected override void Load()
	{
		SetId(30023);
		SetName("One Step Closer to Freedom");
		SetDescription("Talk with the Rimos' Spirit");
		SetTrack("SProgress", "ESuccess", "CATACOMB_38_1_SQ_07_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(194));

		AddObjective("kill0", "Kill 1 Master Genie", new KillObjective(57630, 1));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 7));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_NPC_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_38_1_SQ_07_select", "CATACOMB_38_1_SQ_07", "Tell him not to worry", "Give me some time to prepare"))
			{
				case 1:
					await dialog.Msg("CATACOMB_38_1_SQ_07_agree");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

