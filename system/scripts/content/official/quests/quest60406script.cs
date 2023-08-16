//--- Melia Script -----------------------------------------------------------
// Outer Wall Post (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60406)]
public class Quest60406Script : QuestScript
{
	protected override void Load()
	{
		SetId(60406);
		SetName("Outer Wall Post (3)");
		SetDescription("Talk to Pajauta");
		SetTrack("SProgress", "ESuccess", "PAYAUTA_EP11_7_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_6"));
		AddPrerequisite(new LevelPrerequisite(380));

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_201", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_201", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PAYAUTA_EP11_7_1", "PAYAUTA_EP11_7", "I'm ready.", "Wait for a while"))
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
			await dialog.Msg("PAYAUTA_EP11_7_3");
			await dialog.Msg("FadeOutIN/3000");
			dialog.HideNPC("PAYAUTA_EP11_NPC_201");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

