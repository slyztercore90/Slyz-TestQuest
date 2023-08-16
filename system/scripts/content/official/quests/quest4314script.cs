//--- Melia Script -----------------------------------------------------------
// Eyes of Zachariel (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archivist Jonas.
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

[QuestScript(4314)]
public class Quest4314Script : QuestScript
{
	protected override void Load()
	{
		SetId(4314);
		SetName("Eyes of Zachariel (2)");
		SetDescription("Talk to Archivist Jonas");
		SetTrack("SProgress", "ESuccess", "ROKAS24_KILL1_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_10"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("kill0", "Kill 10 Pino(s)", new KillObjective(401181, 10));
		AddObjective("kill1", "Kill 4 Geppetto(s)", new KillObjective(401101, 4));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_FLORIJONAS3", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_NEALS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS24_KILL1_select01", "ROKAS24_KILL1", "I will light the signal", "It feels like a burden"))
			{
				case 1:
					await dialog.Msg("ROKAS24_KILL1_select02");
					await dialog.Msg("EffectLocalNPC/ROKAS_24_FLORIJONAS3/F_pc_warp_circle/1/BOT");
					dialog.HideNPC("ROKAS_24_FLORIJONAS3");
					await dialog.Msg("FadeOutIN/2000");
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
			await dialog.Msg("ROKAS24_KILL1_succ1");
			dialog.HideNPC("ROKAS_24_FLORIJONAS3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

