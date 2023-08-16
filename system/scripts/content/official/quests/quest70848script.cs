//--- Melia Script -----------------------------------------------------------
// Proof by blood
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70848)]
public class Quest70848Script : QuestScript
{
	protected override void Load()
	{
		SetId(70848);
		SetName("Proof by blood");
		SetDescription("Talk to Indraja");
		SetTrack("SSuccess", "ESuccess", "WHITETREES23_3_SQ09_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ08"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES233_SQ_09_start", "WHITETREES23_3_SQ09", "Propose filling the seal with Kugheri souls", "Say that you don't any ideas"))
			{
				case 1:
					await dialog.Msg("WHITETREES233_SQ_09_agree");
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
			if (character.Inventory.HasItem("WHITETREES23_3_SQ06_ITEM2", 1))
			{
				character.Inventory.RemoveItem("WHITETREES23_3_SQ06_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				dialog.HideNPC("WHITETREES233_SQ_08_2");
				dialog.UnHideNPC("WHITETREES233_SQ_08_3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

