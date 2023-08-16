//--- Melia Script -----------------------------------------------------------
// Cursed Statues (5)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Cursed Statues with the Purification Sphere.
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

[QuestScript(50180)]
public class Quest50180Script : QuestScript
{
	protected override void Load()
	{
		SetId(50180);
		SetName("Cursed Statues (5)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");
		SetTrack("SProgress", "ESuccess", "TABLELAND_73_SQ5_TRACK", "boss_a");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ9"));
		AddPrerequisite(new LevelPrerequisite(250));

		AddObjective("kill0", "Kill 1 Lavenzard", new KillObjective(103040, 1));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 70000));

		AddDialogHook("TABLE73_SUB_ARTIFACT3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT3", "BeforeEnd", BeforeEnd);
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
			// Func/TABLE73_SUBQ5_COMPLETE;
			dialog.AddonMessage("NOTICE_Dm_Clear", "You destroyed the cursed statue!");
			// Func/TABLE73_SUBQ1_COMPLETE;
			await dialog.Msg("EffectLocalNPC/TABLE73_SUB_ARTIFACT3/F_explosion098_dark_blue/1/BOT");
			await dialog.Msg("NPCAin/TABLE73_SUB_ARTIFACT3/DEAD/0");
			dialog.HideNPC("TABLE73_SUB_ARTIFACT3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

