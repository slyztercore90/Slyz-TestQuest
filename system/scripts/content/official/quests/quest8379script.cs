//--- Melia Script -----------------------------------------------------------
// Corrupted Mausoleum (1)
//--- Description -----------------------------------------------------------
// Quest to Go to the 3F of Royal Mausoleum.
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

[QuestScript(8379)]
public class Quest8379Script : QuestScript
{
	protected override void Load()
	{
		SetId(8379);
		SetName("Corrupted Mausoleum (1)");
		SetDescription("Go to the 3F of Royal Mausoleum");

		AddPrerequisite(new CompletedPrerequisite("ZACHA2F_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(87));

		AddObjective("kill0", "Kill 5 Corrupt Vikaras Mage(s)", new KillObjective(57054, 5));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1740));

		AddDialogHook("ZACHA3F_MQ_01_BLACKMAN_01", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA3F_MQ_01_BLACKMAN_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA3F_MQ_01_01", "ZACHA3F_MQ_01", "Say you won't back down", "Say you have to think about it"))
			{
				case 1:
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ZACHA3F_MQ_01_03");
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("ZACHA3F_MQ_01_BLACKMAN_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

