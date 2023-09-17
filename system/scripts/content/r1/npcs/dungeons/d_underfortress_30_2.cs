//--- Melia Script ----------------------------------------------------------
// Extension
//--- Description -----------------------------------------------------------
// NPCs found in and around Extension.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress302NpcScript : GeneralScript
{
	public override void Load()
	{
		// Ruklys Hall of Fame
		//-------------------------------------------------------------------------
		AddNpc(40001, "Ruklys Hall of Fame", "d_underfortress_30_2", 1214.862, -704.8499, 90, "", "UNDERFORTRESS30_2_UNDERFORTRESS30_1", "");
		
		// Evacuation Residential District
		//-------------------------------------------------------------------------
		AddNpc(40001, "Evacuation Residential District", "d_underfortress_30_2", -1696.534, -697.921, -87, "", "UNDERFORTRESS30_2_UNDERFORTRESS30_3", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47192, " ", "d_underfortress_30_2", -960.9432, 1628.18, 93, "UNDER301_MONSTER_PAIR_GIMMICK");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153138, " ", "d_underfortress_30_2", 488.793, -433.8552, 1, "UNDER30_1_BASE_BALL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153134, " ", "d_underfortress_30_2", 832.0229, 471.0039, -28, "UNDER30_2_EVENT2_OBJ1");
	}
}
