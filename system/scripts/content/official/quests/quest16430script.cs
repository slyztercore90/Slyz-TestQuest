//--- Melia Script -----------------------------------------------------------
// Land Bestowed with the Goddess' Power (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(16430)]
public class Quest16430Script : QuestScript
{
	protected override void Load()
	{
		SetId(16430);
		SetName("Land Bestowed with the Goddess' Power (2)");
		SetDescription("Talk with Priest Raeli");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_46_2_MQ_04_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(166));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_AUSTEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_2_MQ_04_select", "SIAULIAI_46_2_MQ_04", "I'll head out. No worries.", "Give me some time to prepare"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_46_2_MQ_04_start_prog");
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
			await dialog.Msg("SIAULIAI_46_2_MQ_04_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_2_MQ_05");
	}
}

