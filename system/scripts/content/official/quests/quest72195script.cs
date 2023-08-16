//--- Melia Script -----------------------------------------------------------
// Search the Remaining Area
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72195)]
public class Quest72195Script : QuestScript
{
	protected override void Load()
	{
		SetId(72195);
		SetName("Search the Remaining Area");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack("SProgress", "ESuccess", "STARTOWER_90_MQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_40"));
		AddPrerequisite(new LevelPrerequisite(379));

		AddObjective("kill0", "Kill 1 Devilglove", new KillObjective(105018, 1));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 19708));

		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_90_STATUE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("STARTOWER_90_MQ_50_DLG1", "STARTOWER_90_MQ_50", "Alright", "Not now."))
			{
				case 1:
					// Func/SCR_STARTOWER_90_MQ_ADAUX_CONNECT_END;
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
		character.Quests.Start("STARTOWER_90_MQ_60");
	}
}

