//--- Melia Script -----------------------------------------------------------
// In their Honor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Pipoti.
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

[QuestScript(1064)]
public class Quest1064Script : QuestScript
{
	protected override void Load()
	{
		SetId(1064);
		SetName("In their Honor (1)");
		SetDescription("Talk to Stonemason Pipoti");
		SetTrack("SProgress", "ESuccess", "ROKAS29_VACYS7_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS5"), new CompletedPrerequisite("ROKAS30_PIPOTI01"));
		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("collect0", "Collect 1 Boulder to be carved into a Memorial Stone", new CollectItemObjective("VACYS_STONE", 1));
		AddDrop("VACYS_STONE", 10f, "boss_Achat_Q2");

		AddObjective("kill0", "Kill 1 Achat", new KillObjective(57305, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("R_Hat_628024", 1));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("ROKAS24_PIPOTI", "BeforeStart", BeforeStart);
		AddDialogHook("BLACKSMITH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS29_VACYS7_select1", "ROKAS29_VACYS7", "I'll accept your request", "I'm busy"))
			{
				case 1:
					await dialog.Msg("ROKAS29_VACYS7_prog1");
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
			if (character.Inventory.HasItem("VACYS_STONE", 1))
			{
				character.Inventory.RemoveItem("VACYS_STONE", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("ROKAS29_VACYS7_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_VACYS8");
	}
}

