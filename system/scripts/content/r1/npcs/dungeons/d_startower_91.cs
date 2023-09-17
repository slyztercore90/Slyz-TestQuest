//--- Melia Script ----------------------------------------------------------
// Astral Tower 20F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 20F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower91NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 12F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 12F", "d_startower_91", 2482, -1924, 0, "", "D_STARTOWER_91_TO_D_STARTOWER_90", "");
		
		// Astral Tower 21F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 21F", "d_startower_91", -2268, 1625, 270, "", "D_STARTOWER_91_TO_D_STARTOWER_92", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_91", 2507, -1137, 0, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155163, "Resistance Soldier", "d_startower_91", 2599, -1529, 270, "D_STARTOWER_91_RESISTANCE_MEMBER_01");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(150180, "Resistance Soldier", "d_startower_91", 2401, -1535, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_02");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156129, "Resistance Soldier", "d_startower_91", 2379, -1369, 180, "D_STARTOWER_91_RESISTANCE_MEMBER_03");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(150179, "Resistance Soldier", "d_startower_91", 2421, -1302, 0, "D_STARTOWER_91_RESISTANCE_MEMBER_04");
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(156116, "Resistance Adjutant", "d_startower_91", 2624, -1289, 135, "D_STARTOWER_91_RESISTANCE_MEMBER_05");
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(156131, "Resistance Adjutant", "d_startower_91", 2668, -1262, -45, "D_STARTOWER_91_RESISTANCE_MEMBER_06");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155164, "Resistance Soldier", "d_startower_91", 2097, -1332, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_07");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(151109, "Protective Device", "d_startower_91", 1107, -2115, 90, "D_STARTOWER_91_1ST_SUB_DEVICE");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(151109, "Protective Device", "d_startower_91", 1444, -70, 90, "D_STARTOWER_91_2ND_SUB_DEVICE");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(151109, "Protective Device", "d_startower_91", 138, -1488, 90, "D_STARTOWER_91_3RD_SUB_DEVICE");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(151109, "Protective Device", "d_startower_91", -59, -294, 90, "D_STARTOWER_91_4TH_SUB_DEVICE_01");
		
		// Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(153137, "Defensive Device", "d_startower_91", -1040, -610, 180, "D_STARTOWER_91_1ST_DEFENCE_DEVICE");
		
		// Elevator Controls
		//-------------------------------------------------------------------------
		AddNpc(153187, "Elevator Controls", "d_startower_91", -1893, 1903, 90, "D_STARTOWER_91_ELEVATER_CONFIG_DEVICE");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_91", 741, 256, 45, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_91", -2129, 1516, 90, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_03");
		
		// Resistance Adjutant Arcadius
		//-------------------------------------------------------------------------
		AddNpc(156115, "Resistance Adjutant Arcadius", "d_startower_91", -894, -1015, 90, "D_STARTOWER_91_RESISTANCE_SENIOR_ARKADIJUS");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155163, "Resistance Soldier", "d_startower_91", 837, 298, 0, "D_STARTOWER_91_RESISTANCE_MEMBER_08");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156128, "Resistance Soldier", "d_startower_91", 839, 222, 225, "D_STARTOWER_91_RESISTANCE_MEMBER_09");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(150179, "Resistance Soldier", "d_startower_91", 812.3074, 258.3079, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_10");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156127, "Resistance Soldier", "d_startower_91", -1925, 1505, 225, "D_STARTOWER_91_RESISTANCE_MEMBER_11");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156126, "Resistance Soldier", "d_startower_91", -1918, 1567, -45, "D_STARTOWER_91_RESISTANCE_MEMBER_12");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_91", 817, -585, 90, "", "D_STARTOWER_91_MQ_60_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_91", -835, 566, 90, "", "D_STARTOWER_91_MQ_90_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_startower_91", -810, -822, 90, "", "D_STARTOWER_91_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 1999.59, -914.7778, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 1363.555, -1340.371, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 1278.025, -2077.467, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 1407.324, -254.4317, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 811.4783, -993.1345, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 214.9686, -452.8471, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 231.0099, -1847.929, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -416.2837, -1003.883, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -828.9007, -501.6103, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -1324.354, -984.6934, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 925.8737, 905.3857, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 968.1367, 1739.943, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -9.171572, 1037.82, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -97.73727, 323.0533, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -1520.069, 1182.628, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", -1143.008, 355.0061, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_91", 795.6636, -149.2745, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(151109, "Protective Device", "d_startower_91", -59, -294, 90, "D_STARTOWER_91_4TH_SUB_DEVICE_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151117, " ", "d_startower_91", -845, -1539, 0, "D_STARTOWER_91_BOOKSHELF_04");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151117, " ", "d_startower_91", -845, -1459, 0, "D_STARTOWER_91_BOOKSHELF_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151117, " ", "d_startower_91", -802, -1539, 0, "D_STARTOWER_91_BOOKSHELF_05");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151117, " ", "d_startower_91", -888, -1539, 0, "D_STARTOWER_91_BOOKSHELF_03");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151117, " ", "d_startower_91", -802, -1459, 0, "D_STARTOWER_91_BOOKSHELF_02");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_startower_91", 2501, -1388, 45, "WARP_D_STARTOWER_91", "STOUP_CAMP", "STOUP_CAMP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_startower_91", -1879.207, 2359.069, 90, "", "EXPLORER_MISLE34", "");
	}
}
