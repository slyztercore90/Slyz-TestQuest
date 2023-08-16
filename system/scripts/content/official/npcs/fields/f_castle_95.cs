//--- Melia Script ----------------------------------------------------------
// Outer Wall District 13
//--- Description -----------------------------------------------------------
// NPCs found in and around Outer Wall District 13.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FCastle95NpcScript : GeneralScript
{
	public override void Load()
	{
		// Resistance Adjutant Antanina
		//-------------------------------------------------------------------------
		AddNpc(4, 156117, "Resistance Adjutant Antanina", "f_castle_95", -1026.745, 86.57175, -442.8207, 0, "CASTLE95_NPC_MAIN01", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(5, 150180, "Detachment Soldier", "f_castle_95", -1023.379, 86.57175, -392.1639, 0, "CASTLE95_NPC_01", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(12, 155163, "Detachment Soldier", "f_castle_95", -977.2556, 86.57175, -393.53, 0, "CASTLE95_NPC_02", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(15, 155165, "Detachment Soldier", "f_castle_95", -1077.17, 86.57175, -393.1283, 0, "CASTLE95_NPC_03", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(16, 147414, "", "f_castle_95", 858.719, 32.34813, -733.5207, 90, "CASTLE95_OBELISK_01", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(41, 147501, "", "f_castle_95", 858.719, 32.34813, -733.5207, 90, "CASTLE95_OBELISK_01_BROKEN", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(17, 147414, "", "f_castle_95", 175, 292, 316, 90, "CASTLE95_OBELISK_02", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(42, 147501, "", "f_castle_95", 175, 292, 316, 90, "CASTLE95_OBELISK_02_BROKEN", "", "");
		
		// Portal
		//-------------------------------------------------------------------------
		AddNpc(18, 154067, "Portal", "f_castle_95", 1626, 377, 1076, 90, "CASTLE95_PORTAL", "", "");
		
		// Resistance Adjutant Antanina
		//-------------------------------------------------------------------------
		AddNpc(19, 156117, "Resistance Adjutant Antanina", "f_castle_95", 1679, 281, 447, 0, "CASTLE95_NPC_MAIN02", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(20, 150180, "Detachment Soldier", "f_castle_95", 1568, 281, 444, 45, "CASTLE95_NPC_04", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(21, 155163, "Detachment Soldier", "f_castle_95", 1576, 281, 338, 135, "CASTLE95_NPC_05", "", "");
		
		// Detachment Soldier
		//-------------------------------------------------------------------------
		AddNpc(22, 155165, "Detachment Soldier", "f_castle_95", 1680, 281, 331, 270, "CASTLE95_NPC_06", "", "");
		AddNpc(25, 153015, "Steering Device", "f_castle_95", 248, 292, 263, 90, "", "", "");
		AddNpc(28, 153015, "Steering Device", "f_castle_95", 248, 292, 371, 90, "", "", "");
		AddNpc(26, 153015, "Steering Device", "f_castle_95", 248, 292, 299, 90, "", "", "");
		AddNpc(27, 153015, "Steering Device", "f_castle_95", 248, 292, 335, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 151018, " ", "f_castle_95", 800, 32, -788, 45, "CASTLE95_SETTING_POINT_01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 151018, " ", "f_castle_95", 804, 32, -676, 45, "CASTLE95_SETTING_POINT_02", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 151018, " ", "f_castle_95", 908, 32, -679, 45, "CASTLE95_SETTING_POINT_03", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(33, 151018, " ", "f_castle_95", 904, 32, -788, 45, "CASTLE95_SETTING_POINT_04", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(34, 151067, " ", "f_castle_95", 800, 32, -788, 135, "CASTLE95_SETTING_POINT_BOX_01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(35, 151067, " ", "f_castle_95", 804, 32, -676, 135, "CASTLE95_SETTING_POINT_BOX_02", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(36, 151067, " ", "f_castle_95", 908, 32, -679, 135, "CASTLE95_SETTING_POINT_BOX_03", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(37, 151067, " ", "f_castle_95", 904, 32, -788, 135, "CASTLE95_SETTING_POINT_BOX_04", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(38, 40095, " ", "f_castle_95", 911, 34, -537, 0, "", "CASTLE95_MAIN03_END", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40, 147414, "", "f_castle_95", 1578.139, 49.92593, -671.3681, 90, "CASTLE95_OBELISK_04", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(39, 147414, "", "f_castle_95", 1327.575, 21.16457, -1793.358, 90, "CASTLE95_OBELISK_03", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(44, 147501, "", "f_castle_95", 1578.139, 49.92593, -671.3681, 90, "CASTLE95_OBELISK_04_BROKEN", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(43, 147501, "", "f_castle_95", 1327.575, 21.16457, -1793.358, 90, "CASTLE95_OBELISK_03_BROKEN", "", "");
		
		// Inner Wall District 10
		//-------------------------------------------------------------------------
		AddNpc(45, 40001, "Inner Wall District 10", "f_castle_95", -1531.582, 38.54451, -603.2539, 270, "", "F_CASTLE_95_TO_F_CASTLE_94", "");
		
		// Outer Wall District 14
		//-------------------------------------------------------------------------
		AddNpc(46, 40001, "Outer Wall District 14", "f_castle_95", 128.9252, 377.0311, 1386.699, 180, "", "F_CASTLE_95_TO_F_CASTLE_96", "");
		
		// Maven 31 Waters
		//-------------------------------------------------------------------------
		AddNpc(47, 40001, "Maven 31 Waters", "f_castle_95", 1868.197, 21.16457, -1831.377, 70, "", "F_CASTLE_95_TO_F_3CMLAKE_27_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(48, 151064, " ", "f_castle_95", 1630.63, 377.02, 1053.86, 0, "CASTLE95_MAIN07_DEVICE", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 646.5165, 34.44456, -847.1511, 90, "CASTLE95_OBJECT", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 646.3225, 34.44456, -784.8403, 90, "CASTLE95_OBJECT", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 662.6659, 49.83287, -588.7074, 45, "CASTLE95_OBJECT", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 712.3152, 49.83287, -534.2278, 45, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 996.0218, 34.44456, -848.6949, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 972.8433, 34.44456, -846.628, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 990.0151, 34.44456, -830.2899, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 967.0598, 34.44456, -825.1258, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 985.6923, 34.44456, -809.2018, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 950.017, 32.34813, -843.3655, 90, "CASTLE95_OBJECT", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 494.963, 123.1976, -844.4252, 90, "CASTLE95_OBJECT", "", "");
		
		// Pile of Explosives
		//-------------------------------------------------------------------------
		AddNpc(49, 155153, "Pile of Explosives", "f_castle_95", 493.5591, 123.1912, -780.6174, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 565.1524, 128.6331, -369.7509, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 588.8917, 128.6359, -369.4813, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 613.2779, 128.6395, -366.3416, 90, "CASTLE95_OBJECT", "", "");
		
		// Explosive Barrel
		//-------------------------------------------------------------------------
		AddNpc(23, 147458, "Explosive Barrel", "f_castle_95", 638.8135, 128.6406, -365.2112, 90, "CASTLE95_OBJECT", "", "");
	}
}
