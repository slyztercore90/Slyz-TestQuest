//--- Melia Script -----------------------------------------------------------
// Information about Saugas (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Eta.
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

[QuestScript(8047)]
public class Quest8047Script : QuestScript
{
	protected override void Load()
	{
		SetId(8047);
		SetName("Information about Saugas (4)");
		SetDescription("Talk to Mercenary Eta");
		SetTrack("SProgress", "ESuccess", "ROKAS26_SUB_Q11_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q10"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 6 Wendigo(s) or Hogma Shaman(s) or Sauga(s)", new KillObjective(6, 41446, 41435, 401001));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_EHTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_EHTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS26_SUB_Q11_01", "ROKAS26_SUB_Q11", "Tell him to install it again", "Tell him to do it himself"))
			{
				case 1:
					dialog.UnHideNPC("ROKAS26_SUB_Q12");
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
			await dialog.Msg("ROKAS26_SUB_Q11_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

