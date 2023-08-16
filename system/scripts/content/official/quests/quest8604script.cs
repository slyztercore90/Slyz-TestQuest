//--- Melia Script -----------------------------------------------------------
// The Immortal Nepenthes (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Erra.
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

[QuestScript(8604)]
public class Quest8604Script : QuestScript
{
	protected override void Load()
	{
		SetId(8604);
		SetName("The Immortal Nepenthes (2)");
		SetDescription("Talk to Watcher Erra");
		SetTrack("SProgress", "ESuccess", "GELE574_MQ_04_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("GELE574_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(35));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("R_HAND02_122", 1));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_ERRA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ERRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE574_MQ_04_01", "GELE574_MQ_04", "I'll be back quickly", "Impossible"))
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
			await dialog.Msg("GELE574_MQ_04_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

