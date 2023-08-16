//--- Melia Script -----------------------------------------------------------
// Headstone on the North of Neryskus Grounds 
//--- Description -----------------------------------------------------------
// Quest to Find the Ancient Headstone and decipher it.
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

[QuestScript(91025)]
public class Quest91025Script : QuestScript
{
	protected override void Load()
	{
		SetId(91025);
		SetName("Headstone on the North of Neryskus Grounds ");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack("SProgress", "ESuccess", "EP12_2_F_CASTLE_101_MQ03_1_TRACK_01", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ03_1_DLG_05", "EP12_2_F_CASTLE_101_MQ03_1"))
			{
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

