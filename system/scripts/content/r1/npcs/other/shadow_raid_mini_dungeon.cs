//--- Melia Script ----------------------------------------------------------
// Hidden Dimension
//--- Description -----------------------------------------------------------
// NPCs found in and around Hidden Dimension.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class ShadowRaidMiniDungeonNpcScript : GeneralScript
{
	public override void Load()
	{
		// 
		//-------------------------------------------------------------------------
		AddNpc(151041, "", "shadow_raid_mini_dungeon", -138, 189, 45, "CASTLE102_AUSTEJA_02");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(154086, "", "shadow_raid_mini_dungeon", -99, 189, 0, "CASTLE102_MQ_06_VIVORA");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154066, " ", "shadow_raid_mini_dungeon", -218, 188, 90, "ANOTHER_SPACE_PORTAL");
	}
}
