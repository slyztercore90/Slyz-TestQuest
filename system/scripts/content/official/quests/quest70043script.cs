//--- Melia Script -----------------------------------------------------------
// Of Father, by Father (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gord Shaton.
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

[QuestScript(70043)]
public class Quest70043Script : QuestScript
{
	protected override void Load()
	{
		SetId(70043);
		SetName("Of Father, by Father (1)");
		SetDescription("Talk to Gord Shaton");
		SetTrack("SProgress", "ESuccess", "FARM49_3_MQ04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("FARM49_3_MQ03"));
		AddPrerequisite(new LevelPrerequisite(155));

		AddDialogHook("FARM493_MQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_3_MQ_04_1", "FARM49_3_MQ04", "He may do something dangerous so keep looking at him", "Leave here since you feel something dangerous"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM49_3_MQ05");
	}
}

