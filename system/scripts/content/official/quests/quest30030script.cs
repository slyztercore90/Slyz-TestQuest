//--- Melia Script -----------------------------------------------------------
// What's Bad About Being Careful (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30030)]
public class Quest30030Script : QuestScript
{
	protected override void Load()
	{
		SetId(30030);
		SetName("What's Bad About Being Careful (2)");
		SetDescription("Talk to Jane's Spirit");
		SetTrack("SProgress", "ESuccess", "CATACOMB_02_SQ_07_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_02_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(197));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(57631, 1));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 6107));

		AddDialogHook("CATACOMB_02_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_02_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_02_SQ_07_select", "CATACOMB_02_SQ_07", "All prepared", "I'm not ready yet"))
			{
				case 1:
					await dialog.Msg("CATACOMB_02_SQ_07_agree");
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
			await dialog.Msg("CATACOMB_02_SQ_07_succ");
			await dialog.Msg("EffectLocalNPC/CATACOMB_02_NPC_01/F_light003_blue/0.5/MID");
			dialog.HideNPC("CATACOMB_02_NPC_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

