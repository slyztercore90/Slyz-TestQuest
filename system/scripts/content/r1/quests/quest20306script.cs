//--- Melia Script -----------------------------------------------------------
// Endlessly Blasphemous
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Inea.
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

[QuestScript(20306)]
public class Quest20306Script : QuestScript
{
	protected override void Load()
	{
		SetId(20306);
		SetName("Endlessly Blasphemous");
		SetDescription("Talk to Priest Inea");

		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ01", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_SQ01_select", "CHATHEDRAL53_SQ01", "I will retrieve the Relics", "I'm not interested"))
		{
			case 1:
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT01");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT02");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT03");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT04");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT05");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT06");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT07");
				dialog.UnHideNPC("CHATHEDRAL53_SQ01_OBJECT08");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CHATHEDRAL53_SQ01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

