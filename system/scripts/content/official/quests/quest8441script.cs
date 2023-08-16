//--- Melia Script -----------------------------------------------------------
// Disgrace
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8441)]
public class Quest8441Script : QuestScript
{
	protected override void Load()
	{
		SetId(8441);
		SetName("Disgrace");
		SetDescription("Talk to the Guardian Stone Statue");
		SetTrack("SProgress", "ESuccess", "ZACHA3F_SQ_04_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(88));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(57095, 1));
		AddObjective("kill1", "Kill 2 Canyon Area Device 5(s)", new KillObjective(47106, 2));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("ZACHA3F_SQ04_GUARD", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA3F_SQ04_GUARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA3F_SQ_04_01", "ZACHA3F_SQ_04", "I'll destroy the Royal Magic Control Device", "I'll wait a little bit"))
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ZACHA3F_SQ_04_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

