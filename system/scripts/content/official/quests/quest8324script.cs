//--- Melia Script -----------------------------------------------------------
// Opening the Barrier (2)
//--- Description -----------------------------------------------------------
// Quest to Soul and conversation of Assistant.
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

[QuestScript(8324)]
public class Quest8324Script : QuestScript
{
	protected override void Load()
	{
		SetId(8324);
		SetName("Opening the Barrier (2)");
		SetDescription("Soul and conversation of Assistant");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_18_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_17"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Evil Spirit(s)", new KillObjective(400103, 6));

		AddDialogHook("KATYN18_KEEPER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_18_01", "KATYN18_MQ_18", "I willing to talk of soul in owl image", "Cancel"))
			{
				case 1:
					dialog.UnHideNPC("KATYN18_FENCE");
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
			await dialog.Msg("KATYN18_MQ_18_03");
			dialog.HideNPC("KATYN18_FENCE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_19");
	}
}

