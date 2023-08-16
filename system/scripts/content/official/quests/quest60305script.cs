//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60305)]
public class Quest60305Script : QuestScript
{
	protected override void Load()
	{
		SetId(60305);
		SetName("The Fugitive's Dream (8)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack("SProgress", "ESuccess", "DCAPITAL107_SQ_8_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(378));

		AddObjective("kill0", "Kill 1 Banshee Boss", new KillObjective(103052, 1));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 39000));
		AddReward(new ItemReward("misc_ore15", 2));

		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL107_SQ_8_1", "DCAPITAL107_SQ_8", "I am ready", "I need to prepare"))
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
			await dialog.Msg("DCAPITAL107_SQ_8_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

