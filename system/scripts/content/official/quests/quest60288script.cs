//--- Melia Script -----------------------------------------------------------
// The Essentials for Survival
//--- Description -----------------------------------------------------------
// Quest to Talk to the rescued Kupole.
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

[QuestScript(60288)]
public class Quest60288Script : QuestScript
{
	protected override void Load()
	{
		SetId(60288);
		SetName("The Essentials for Survival");
		SetDescription("Talk to the rescued Kupole");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(371));

		AddObjective("kill0", "Kill 12 Bishop Star(s)", new KillObjective(59092, 12));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("DCAPITAL105_KUPOLE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL105_KUPOLE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL105_SQ_8_1", "DCAPITAL105_SQ_8", "I'll take care of it", "Hide well."))
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
			await dialog.Msg("DCAPITAL105_SQ_8_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

