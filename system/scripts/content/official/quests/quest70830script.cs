//--- Melia Script -----------------------------------------------------------
// Oil and water
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Mylija.
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

[QuestScript(70830)]
public class Quest70830Script : QuestScript
{
	protected override void Load()
	{
		SetId(70830);
		SetName("Oil and water");
		SetDescription("Talk to Refugee Mylija");
		SetTrack("SProgress", "ESuccess", "MAPLE23_2_SQ11_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ03"));
		AddPrerequisite(new LevelPrerequisite(319));

		AddDialogHook("MAPLE232_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_12", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE232_SQ_11_start", "MAPLE23_2_SQ11"))
			{
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MAPLE23_2_SQ12");
	}
}

