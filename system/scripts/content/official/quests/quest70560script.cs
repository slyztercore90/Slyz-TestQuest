//--- Melia Script -----------------------------------------------------------
// The Last Hope
//--- Description -----------------------------------------------------------
// Quest to Rescue the Monk being chased by Demons.
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

[QuestScript(70560)]
public class Quest70560Script : QuestScript
{
	protected override void Load()
	{
		SetId(70560);
		SetName("The Last Hope");
		SetDescription("Rescue the Monk being chased by Demons");
		SetTrack("SPossible", "ESuccess", "PILGRIM41_3_SQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(268));

		AddObjective("kill0", "Kill 5 Green Minos(s) or Green Minos Archer(s)", new KillObjective(5, 57921, 57924));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
					await dialog.Msg("PILGRIM413_SQ_01_succ1");
					await dialog.Msg("자신이 바로 계시자임을 밝힌다");
			await dialog.Msg("PILGRIM413_SQ_01_succ2");
			dialog.UnHideNPC("ABBEY416_SQ_01");
			dialog.HideNPC("ABBEY416_SQ_01_1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

