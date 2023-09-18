//--- Melia Script ----------------------------------------------------------
// Resident Quarter
//--- Description -----------------------------------------------------------
// NPCs found in and around Resident Quarter.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress67NpcScript : GeneralScript
{
	public override void Load()
	{
		// Drill Ground of Confliction
		//-------------------------------------------------------------------------
		AddNpc(40001, "Drill Ground of Confliction", "d_underfortress_67", 31.74275, -1661.218, -33, "", "UNDERFORTRESS67_UNDERFORTRESS66", "");
		
		// Storage Quarter
		//-------------------------------------------------------------------------
		AddNpc(40001, "Storage Quarter", "d_underfortress_67", 350.6508, 545.6928, 176, "", "UNDERFORTRESS67_UNDERFORTRESS68", "");
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_67", 95.13548, -1444.122, 90, "AMANDA_67_1");
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_67", 95.15773, -1444.222, 84, "AMANDA_67_2");
		
		// Old Manager
		//-------------------------------------------------------------------------
		AddNpc(153139, "Old Manager", "d_underfortress_67", 438.0723, -509.9649, 90, "EMINENT_67_1");
		
		// Old Manager
		//-------------------------------------------------------------------------
		AddNpc(153139, "Old Manager", "d_underfortress_67", 62.61678, -277.8322, 90, "EMINENT_67_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147311, " ", "d_underfortress_67", -1426.489, -953.4346, -13, "UNDER67_BOOK1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153014, " ", "d_underfortress_67", 1622.989, -1651.721, 103, "UNDER67_BOOK2");
		
		// Soldier's Grave
		//-------------------------------------------------------------------------
		AddNpc(47170, "Soldier's Grave", "d_underfortress_67", 1769.679, 778.6597, 17, "UNDER67_SQ020");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147306, " ", "d_underfortress_67", 459.1349, -509.825, 52, "", "UNDER67_MQ060_DEVICE", "");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1673.589, -344.9592, 37, "UNDER67_GRASS");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1466.189, -903.1689, 82, "UNDER67_GRASS");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1709.322, -558.177, 49, "UNDER67_GRASS");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1845.789, -1411.205, 90, "UNDER67_GRASS");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1155.378, -852.9885, 99, "UNDER67_GRASS");
		
		// The soldier with the resentment
		//-------------------------------------------------------------------------
		AddNpc(11283, "The soldier with the resentment", "d_underfortress_67", 1776, 802, 0, "UNDER67_SQ030");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147312, " ", "d_underfortress_67", 451.6524, -458.2003, 44, "", "UNDER67_MQ6_TO_MEMO", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_underfortress_67", 453.1417, -456.7138, 45, "UNDER67_MQ060");
		
		// Mushroom
		//-------------------------------------------------------------------------
		AddNpc(155023, "Mushroom", "d_underfortress_67", 1282.825, -327.5097, 90, "UNDER67_GRASS");
		
		// Ruklys Hall of Fame
		//-------------------------------------------------------------------------
		AddNpc(40001, "Ruklys Hall of Fame", "d_underfortress_67", 884.1856, 2.983585, -23, "", "UNDERFORTRESS67_UNDERFORTRESS30_1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20024, "", "d_underfortress_67", 75.42, -768.88, 90, "", "UNDER67_HIDDENQ1_AREA3", "");
	}
}
