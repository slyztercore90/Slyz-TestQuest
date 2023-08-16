//--- Melia Script -----------------------------------------------------------
// Seal of the Royal Family (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gustas Jonas.
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

[QuestScript(20137)]
public class Quest20137Script : QuestScript
{
	protected override void Load()
	{
		SetId(20137);
		SetName("Seal of the Royal Family (3)");
		SetDescription("Talk to Gustas Jonas");

		AddPrerequisite(new CompletedPrerequisite("ROKAS25_REXIPHER4"));
		AddPrerequisite(new LevelPrerequisite(61));

		AddDialogHook("ROKAS25_REXIPHER5", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_REXIPHER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS25_REXIPHER6_01", "ROKAS25_REXIPHER6", "I'll release the final seal", "I need a minute prepare"))
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
			await dialog.Msg("ROKAS25_REXIPHER6_03");
			await dialog.Msg("EffectLocalNPC/ROKAS25_ZACHARIEL32/I_force003_green/1/BOT");
			dialog.UnHideNPC("ROKAS25_ZACHARIEL32");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

