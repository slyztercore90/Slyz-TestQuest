//--- Melia Script -----------------------------------------------------------
// There is a Way (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30028)]
public class Quest30028Script : QuestScript
{
	protected override void Load()
	{
		SetId(30028);
		SetName("There is a Way (4)");
		SetDescription("Talk to Jane's Spirit");
		SetTrack("SProgress", "ESuccess", "CATACOMB_02_SQ_05_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_02_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(197));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 6107));

		AddDialogHook("CATACOMB_02_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_02_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_02_SQ_05_select", "CATACOMB_02_SQ_05", "I will go to the Room of Ancestral Rituals", "I need some time to think"))
			{
				case 1:
					await dialog.Msg("CATACOMB_02_SQ_05_agree");
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
			await dialog.Msg("CATACOMB_02_SQ_05_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_02_SQ_06");
	}
}

