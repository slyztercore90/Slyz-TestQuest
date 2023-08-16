//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8474)]
public class Quest8474Script : QuestScript
{
	protected override void Load()
	{
		SetId(8474);
		SetName("Goddess Gabija (4)");
		SetDescription("Talk to Grita");
		SetTrack("SProgress", "ESuccess", "FTOWER41_MQ_02_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("kill0", "Kill 6 Phyracon(s)", new KillObjective(47397, 6));
		AddObjective("kill1", "Kill 8 Drake(s)", new KillObjective(401621, 8));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER41_MQ_02_01", "FTOWER41_MQ_02", "Move to the Magic Transport Field.", "Let's find a safer way. "))
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
			await dialog.Msg("FTOWER41_MQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_MQ_03");
	}
}

