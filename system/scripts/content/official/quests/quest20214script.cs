//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (2)
//--- Description -----------------------------------------------------------
// Quest to Find Agailla Flurry's gravestones .
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

[QuestScript(20214)]
public class Quest20214Script : QuestScript
{
	protected override void Load()
	{
		SetId(20214);
		SetName("Flurry's Epitaphs (2)");
		SetDescription("Find Agailla Flurry's gravestones ");

		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ01"));
		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("collect0", "Collect 2 Destroyed Tombstone Fragment(s)", new CollectItemObjective("REMAINS39_STONESLATE", 2));
		AddDrop("REMAINS39_STONESLATE", 4f, "hook");

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_MQ_MONUMENT2", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_MQ_MONUMENT2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS39_MQ02_select01", "REMAINS39_MQ02", "Look for tombstone pieces from surrounding monsters.", "Let's quit since you don't know where it is"))
			{
				case 1:
					dialog.AddonMessage("NOTICE_Dm_Exclaimation", "The remaining parts are unreadable", 3);
					character.Quests.Start(this.QuestId);
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
			if (character.Inventory.HasItem("REMAINS39_STONESLATE", 2))
			{
				character.Inventory.RemoveItem("REMAINS39_STONESLATE", 2);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("REMAINS39_MQ02_succ01");
				dialog.AddonMessage("NOTICE_Dm_Clear", "You've read a tombstone of Agailla Flurry{nl}Read the other tombstones to obtain the artifacts of Flurry");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

