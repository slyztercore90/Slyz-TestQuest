//--- Melia Script -----------------------------------------------------------
// Road to the Mausoleum
//--- Description -----------------------------------------------------------
// Quest to Ask Goddess Saule about the revelation.
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

[QuestScript(18010)]
public class Quest18010Script : QuestScript
{
	protected override void Load()
	{
		SetId(18010);
		SetName("Road to the Mausoleum");
		SetDescription("Ask Goddess Saule about the revelation");
		SetTrack("SProgress", "ESuccess", "HUEVILLAGE_58_4_MQ11_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ08"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 132));
		AddReward(new ItemReward("stonetablet03", 1));
		AddReward(new ItemReward("Vis", 10440));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("HUEVILLAGE_58_4_MQ11_select", "HUEVILLAGE_58_4_MQ11", "Show the revelation", "I'm not ready yet"))
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
}

