//--- Melia Script -----------------------------------------------------------
// Suspicious Voice
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

[QuestScript(17007)]
public class Quest17007Script : QuestScript
{
	protected override void Load()
	{
		SetId(17007);
		SetName("Suspicious Voice");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 5 Blindlem(s)", new KillObjective(57042, 5));
		AddObjective("kill1", "Kill 5 Belegg(s)", new KillObjective(57051, 5));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER42_SQ_01_ST", "FTOWER42_SQ_01", "Defeat it", "It's strange so just ignore it"))
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
			await dialog.Msg("FTOWER42_SQ_01_COMP");
			await dialog.Msg("NPCChat/FTOWER42_SQ_01/이제 자유로와 질 수 있어..");
			await dialog.Msg("EffectLocalNPC/FTOWER42_SQ_01/F_archer_scarecrow_shot_smoke/2/BOT");
			dialog.HideNPC("FTOWER42_SQ_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

