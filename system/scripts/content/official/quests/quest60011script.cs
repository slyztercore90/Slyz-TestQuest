//--- Melia Script -----------------------------------------------------------
// Lodged Stone
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60011)]
public class Quest60011Script : QuestScript
{
	protected override void Load()
	{
		SetId(60011);
		SetName("Lodged Stone");
		SetDescription("Talk to Kupole Arune");
		SetTrack("SProgress", "ESuccess", "VPRISON512_MQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_04"), new CompletedPrerequisite("VPRISON512_MQ_01"), new CompletedPrerequisite("VPRISON512_MQ_02"), new CompletedPrerequisite("VPRISON512_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(154));

		AddObjective("kill0", "Kill 1 Demon Lord Nuaele", new KillObjective(57412, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 31262));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON512_MQ_05_01", "VPRISON512_MQ_05", "I am ready", "I need to prepare"))
			{
				case 1:
					dialog.UnHideNPC("VPRISON512_MQ_ALDONA");
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
			await dialog.Msg("VPRISON512_MQ_05_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

