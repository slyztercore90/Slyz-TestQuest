//--- Melia Script -----------------------------------------------------------
// Reading Time
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

[QuestScript(70604)]
public class Quest70604Script : QuestScript
{
	protected override void Load()
	{
		SetId(70604);
		SetName("Reading Time");
		SetDescription("Talk to Monk Stella");
		SetTrack("SProgress", "ESuccess", "ABBEY41_6_SQ05_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ04"));
		AddPrerequisite(new LevelPrerequisite(274));

		AddObjective("kill0", "Kill 9 Red Ticen(s) or Red Ticen Magician(s) or Red Ticen Crossbow Soldier(s) or Red Nuo(s)", new KillObjective(9, 57957, 57961, 57959, 57984));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY416_SQ_05_start", "ABBEY41_6_SQ05", "Ask that she hurry", "Ask if she can't hide somewhere while she reads"))
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
			await dialog.Msg("ABBEY416_SQ_05_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

