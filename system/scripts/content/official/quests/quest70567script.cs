//--- Melia Script -----------------------------------------------------------
// Demons cannot be forgiven
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70567)]
public class Quest70567Script : QuestScript
{
	protected override void Load()
	{
		SetId(70567);
		SetName("Demons cannot be forgiven");
		SetDescription("Talk to Monk Stella");
		SetTrack("SPossible", "ESuccess", "PILGRIM41_3_SQ08_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ07"));
		AddPrerequisite(new LevelPrerequisite(268));

		AddObjective("kill0", "Kill 1 Brown Riteris", new KillObjective(58430, 1));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 5));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_08_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM413_SQ_08_start", "PILGRIM41_3_SQ08"))
			{
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
			await dialog.Msg("PILGRIM413_SQ_08_succ");
			dialog.HideNPC("PILGRIM413_SQ_08_1");
			await dialog.Msg("FadeOutIN/1000");
			dialog.UnHideNPC("PILGRIM415_SQ_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

