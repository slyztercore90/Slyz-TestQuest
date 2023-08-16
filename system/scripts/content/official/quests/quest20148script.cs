//--- Melia Script -----------------------------------------------------------
// Raided Historian
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Adelle.
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

[QuestScript(20148)]
public class Quest20148Script : QuestScript
{
	protected override void Load()
	{
		SetId(20148);
		SetName("Raided Historian");
		SetDescription("Talk to Historian Adelle");
		SetTrack("SProgress", "ESuccess", "ROKAS28_MQ6_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS28_MQ2"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_ODEL", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_ODEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS28_MQ6_select1", "ROKAS28_MQ6", "It reacts the same just like Nian's stone", "It's nothing serious"))
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
			dialog.HideNPC("ROKAS28_ODEL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

