//--- Melia Script -----------------------------------------------------------
// Curse, Begone! (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Royal Soldier Spirit.
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

[QuestScript(72227)]
public class Quest72227Script : QuestScript
{
	protected override void Load()
	{
		SetId(72227);
		SetName("Curse, Begone! (1)");
		SetDescription("Talk to the Royal Soldier Spirit");
		SetTrack("SProgress", "ESuccess", "CASTLE94_MAIN05_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE94_MAIN04"));
		AddPrerequisite(new LevelPrerequisite(395));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_MAIN02", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE94_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE94_MAIN05_01", "CASTLE94_MAIN05", "Alright", "Ugh, I can't stand traps."))
			{
				case 1:
					dialog.HideNPC("CASTLE94_MAIN05_SHIELD");
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE94_MAIN06");
	}
}

