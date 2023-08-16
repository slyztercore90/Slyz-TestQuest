//--- Melia Script -----------------------------------------------------------
// Release Me
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17011)]
public class Quest17011Script : QuestScript
{
	protected override void Load()
	{
		SetId(17011);
		SetName("Release Me");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 5 Blindlem(s)", new KillObjective(57042, 5));
		AddObjective("kill1", "Kill 10 Shaman Doll(s)", new KillObjective(47398, 10));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER42_SQ_05_ST", "FTOWER42_SQ_05", "I'll release you", "Ignore"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("FTOWER42_SQ_05_COMP");
			await dialog.Msg("NPCChat/FTOWER42_SQ_05/속박에서 풀려난다..");
			await dialog.Msg("EffectLocalNPC/FTOWER42_SQ_05/F_archer_scarecrow_shot_smoke/2/MID");
			dialog.HideNPC("FTOWER42_SQ_05");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

