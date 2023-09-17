//--- Melia Script ----------------------------------------------------------
// Grand Corridor
//--- Description -----------------------------------------------------------
// NPCs found in and around Grand Corridor.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCathedral54NpcScript : GeneralScript
{
	public override void Load()
	{
		// Main Building
		//-------------------------------------------------------------------------
		AddNpc(40001, "Main Building", "d_cathedral_54", 1218.897, -380.2193, 92, "", "CATHEDRAL54_CATHEDRAL53", "");
		
		// Penitence Route
		//-------------------------------------------------------------------------
		AddNpc(40001, "Penitence Route", "d_cathedral_54", -1824, -566, 270, "", "CATHEDRAL54_PILGRIM55", "");
		
		// Penitence Route
		//-------------------------------------------------------------------------
		AddNpc(40001, "Penitence Route", "d_cathedral_54", -1474, 1122, 180, "", "CATHEDRAL54_PILGRIM55_RE", "");
		
		// Sanctuary
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sanctuary", "d_cathedral_54", 1176.995, 593.0758, 87, "", "CATHEDRAL54_CATHEDRAL56", "");
		
		// Priest Daram
		//-------------------------------------------------------------------------
		AddNpc(147386, "Priest Daram", "d_cathedral_54", 910.6841, -164.4541, 60, "CHATHEDRAL54_SQ01_PART1", "CHATHEDRAL54_SQ01_PART1_IN");
		
		// Priest Yosana
		//-------------------------------------------------------------------------
		AddNpc(147397, "Priest Yosana", "d_cathedral_54", 1051.284, -65.45916, 31, "CHATHEDRAL54_SQ03_PART1");
		
		// Priest Ruodell
		//-------------------------------------------------------------------------
		AddNpc(147398, "Priest Ruodell", "d_cathedral_54", 927.064, 494.9588, 168, "CHATHEDRAL54_SQ04_PART2");
		
		// Karuna Altar
		//-------------------------------------------------------------------------
		AddNpc(47254, "Karuna Altar", "d_cathedral_54", 826.3354, 1200.755, -3, "CHATHEDRAL54_MQ04_PART2");
		
		// Bishop Aurelius' Spirit
		//-------------------------------------------------------------------------
		AddNpc(151033, "Bishop Aurelius' Spirit", "d_cathedral_54", -970.2767, -618.5256, 116, "CHATHEDRAL54_PART1_BISHOP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153015, " ", "d_cathedral_54", -912.17, -915.22, 90, "", "CHATHEDRAL54_PART1_OBJ1", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153015, " ", "d_cathedral_54", -1499.22, -913.37, 90, "", "CHATHEDRAL54_PART1_OBJ2", "");
		
		// Books dropped on the floor
		//-------------------------------------------------------------------------
		AddNpc(147311, "Books dropped on the floor", "d_cathedral_54", 184.0998, 1074.551, 84, "CHATHEDRAL54_SQ01_PART1_BOOK1");
		
		// Old Book
		//-------------------------------------------------------------------------
		AddNpc(153014, "Old Book", "d_cathedral_54", 109.414, 1366.865, 148, "CHATHEDRAL54_SQ01_PART1_BOOK2");
		
		// Old Book
		//-------------------------------------------------------------------------
		AddNpc(153014, "Old Book", "d_cathedral_54", 371.4471, 1332.722, 90, "CHATHEDRAL54_SQ01_PART1_BOOK3");
		
		// Bishop Aurelius' Spirit
		//-------------------------------------------------------------------------
		AddNpc(151033, "Bishop Aurelius' Spirit", "d_cathedral_54", -1203.815, 993.4829, 86, "CHATHEDRAL54_BISHOP_AFTER");
		
		// Platform of Love
		//-------------------------------------------------------------------------
		AddNpc(47254, "Platform of Love", "d_cathedral_54", -1500.943, -1050.348, 178, "CHATHEDRAL54_MQ01_PUZZLE");
		
		// Maven's Message
		//-------------------------------------------------------------------------
		AddNpc(47254, "Maven's Message", "d_cathedral_54", 1514, -1900, 88, "CHATHEDRAL54_MQ06_BOOK");
		
		// Portal
		//-------------------------------------------------------------------------
		AddNpc(151019, "Portal", "d_cathedral_54", 1542.78, -2296.361, 90, "CHATHEDRAL54_POTAL");
		
		// Old Book
		//-------------------------------------------------------------------------
		AddNpc(153014, "Old Book", "d_cathedral_54", 334.1398, 855.1437, 90, "CHATHEDRAL54_SQ01_PART1_BOOK4");
		
		// Symbol of Spiritual Power
		//-------------------------------------------------------------------------
		AddNpc(151001, "Symbol of Spiritual Power", "d_cathedral_54", -877.76, 992.09, 90, "CATHEDRAL54MQ02_OBJECT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147350, " ", "d_cathedral_54", 1580, -1857, -2, "", "CHATHEDRAL_GATE_NPC", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(153028, "", "d_cathedral_54", 1584.3, -1864.7, 90, "", "CATHEDRAL54_HIDDEN_WALL", "");
		
		// Priest of Evidence
		//-------------------------------------------------------------------------
		AddNpc(103046, "Priest of Evidence", "d_cathedral_54", 1590, -1935, -2, "MQ05_PROOF_PRIST");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154043, " ", "d_cathedral_54", 1549.333, -1358.994, 0, "", "CHATHEDRAL_FINAL_NPC", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cathedral_54", -1353.72, -736.48, 90, "TREASUREBOX_LV_D_CATHEDRAL_5459");
	}
}
