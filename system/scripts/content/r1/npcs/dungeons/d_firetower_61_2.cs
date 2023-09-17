//--- Melia Script ----------------------------------------------------------
// Roxona Reconstruction Agency East Building
//--- Description -----------------------------------------------------------
// NPCs found in and around Roxona Reconstruction Agency East Building.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower612NpcScript : GeneralScript
{
	public override void Load()
	{
		// Roxona Reconstruction Agency West Building
		//-------------------------------------------------------------------------
		AddNpc(40001, "Roxona Reconstruction Agency West Building", "d_firetower_61_2", -1891.504, -1702.749, 0, "", "FIRETOWER612_TO_FIRETOWER611", "");
		
		// North Side
		//-------------------------------------------------------------------------
		AddNpc(147469, "North Side", "d_firetower_61_2", -2074, 1347, 90, "FD_FIRETOWER612_T01_GATE_NOUTH_RUN_2");
		
		// South Side
		//-------------------------------------------------------------------------
		AddNpc(147469, "South Side", "d_firetower_61_2", 1695, -1557, 90, "FD_FIRETOWER612_T01_GATE_SOUTH_RUN_2");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_firetower_61_2", 905.93, 400.7, 225, "TREASUREBOX_LV_D_FIRETOWER_61_21000");
	}
}
