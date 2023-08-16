//--- Melia Script -----------------------------------------------------------
// Eternal Sleep of the Owls
//--- Description -----------------------------------------------------------
// Quest to Talk with the Weak Owl.
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

[QuestScript(20074)]
public class Quest20074Script : QuestScript
{
	protected override void Load()
	{
		SetId(20074);
		SetName("Eternal Sleep of the Owls");
		SetDescription("Talk with the Weak Owl");
		SetTrack("SProgress", "ESuccess", "KATYN13_ADDQUEST4_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("KATYN13_NEWSUB_02"));
		AddPrerequisite(new LevelPrerequisite(112));

		AddObjective("kill0", "Kill 7 High Vubbe(s)", new KillObjective(41405, 7));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN13_ADDQUEST4_select1", "KATYN13_ADDQUEST4", "Alright, I'll help you", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("KATYN13_ADDQUEST4_select1_a");
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
			await dialog.Msg("KATYN13_ADDQUEST4_COMP");
			dialog.UnHideNPC("KATYN13_ADDQUEST1_NPC");
			dialog.UnHideNPC("KATYN13_ADDQUEST2_NPC");
			dialog.UnHideNPC("KATYN13_ADDQUEST3_NPC");
			dialog.UnHideNPC("KATYN13_ADDQUEST8_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

