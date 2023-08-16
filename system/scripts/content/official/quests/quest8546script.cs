//--- Melia Script -----------------------------------------------------------
// Foreseen Crisis (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(8546)]
public class Quest8546Script : QuestScript
{
	protected override void Load()
	{
		SetId(8546);
		SetName("Foreseen Crisis (2)");
		SetDescription("Talk to the Paladin Master");
		SetTrack("SProgress", "ESuccess", "GELE573_MQ_09_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("GELE573_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(32));

		AddObjective("kill0", "Kill 1 Throneweaver", new KillObjective(57094, 1));

		AddReward(new ItemReward("R_TOP02_118", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE573_MQ_09_01", "GELE573_MQ_09", "Yes, I'll help you concentrate", "I'll wait a little bit"))
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("GELE573_MQ_08");
	}
}

