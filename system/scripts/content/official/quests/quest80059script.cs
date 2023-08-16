//--- Melia Script -----------------------------------------------------------
// The Unfolding Truth
//--- Description -----------------------------------------------------------
// Quest to Stop Faustas.
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

[QuestScript(80059)]
public class Quest80059Script : QuestScript
{
	protected override void Load()
	{
		SetId(80059);
		SetName("The Unfolding Truth");
		SetDescription("Stop Faustas");
		SetTrack("SProgress", "ESuccess", "TABLELAND_11_1_SQ_08_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_07"));
		AddPrerequisite(new LevelPrerequisite(208));

		AddObjective("kill0", "Kill 1 Saltistter", new KillObjective(58295, 1));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("TABLELAND_11_1_BOOK_1", 1));
		AddReward(new ItemReward("expCard11", 5));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_SQ_07_ENDNPC", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_FAUSTAS", "BeforeEnd", BeforeEnd);
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
			dialog.UnHideNPC("TABLELAND_11_1_DARK_EFF");
			await Task.Delay(500);
			await dialog.Msg("TABLELAND_11_1_SQ_08_succ");
			await dialog.Msg("NPCAin/TABLELAND_11_1_FAUSTAS/knockdown/1");
			dialog.UnHideNPC("TABLELAND_11_1_FAUSTAS_DOWN");
			dialog.HideNPC("TABLELAND_11_1_FAUSTAS");
			await dialog.Msg("EffectLocalNPC/TABLELAND_11_1_KRUVINA/I_spell_crystal_gem_red_parts_mash/0.8/MID");
			dialog.HideNPC("TABLELAND_11_1_KRUVINA");
			dialog.HideNPC("TABLELAND_11_1_DARK_EFF");
			dialog.HideNPC("TABLELAND_11_1_FROST_GUARD");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

