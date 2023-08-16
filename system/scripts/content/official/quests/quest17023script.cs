//--- Melia Script -----------------------------------------------------------
// Hot-blooded Simon Shaw (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Simon Shaw.
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

[QuestScript(17023)]
public class Quest17023Script : QuestScript
{
	protected override void Load()
	{
		SetId(17023);
		SetName("Hot-blooded Simon Shaw (2)");
		SetDescription("Talk to Simon Shaw");

		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(126));

		AddObjective("kill0", "Kill 8 Dimmer(s)", new KillObjective(47395, 8));
		AddObjective("kill1", "Kill 5 Black Shaman Doll(s)", new KillObjective(47399, 5));
		AddObjective("kill2", "Kill 5 Black Drake(s)", new KillObjective(401623, 5));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER45_SQ_02_ST", "FTOWER45_SQ_02", "Don't worry", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/FTOWER45_SQ_01/F_pc_warp_circle/0.5/BOT");
					dialog.HideNPC("FTOWER45_SQ_01");
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
			dialog.UnHideNPC("FTOWER45_SQ_03");
			await dialog.Msg("FTOWER45_SQ_02_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER45_SQ_03");
	}
}

