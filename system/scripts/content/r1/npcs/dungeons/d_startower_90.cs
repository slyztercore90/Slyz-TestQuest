//--- Melia Script ----------------------------------------------------------
// Astral Tower 12F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 12F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower90NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 4F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 4F", "d_startower_90", 1875, -905, 90, "", "D_STARTOWER_90_TO_D_STARTOWER_89", "");
		
		// Astral Tower 20F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 20F", "d_startower_90", 817.5574, 2402.892, 180, "", "D_STARTOWER_90_TO_D_STARTOWER_91", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_90", 1740, -860, 0, "D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155163, "Resistance Soldier", "d_startower_90", 1700, -866, 45, "D_STARTOWER_90_RESISTANCE_MEMBER_01_1");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156127, "Resistance Soldier", "d_startower_90", 1685, -978, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_02_1");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155165, "Resistance Soldier", "d_startower_90", 1747, -974, 270, "D_STARTOWER_90_RESISTANCE_MEMBER_03_1");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_90", 540, 2057, 135, "D_STARTOWER_90_RESISTANCE_LEADER_BAYL_02");
		
		// Elder Adaux
		//-------------------------------------------------------------------------
		AddNpc(150178, "Elder Adaux", "d_startower_90", 608, 2122, 0, "D_STARTOWER_90_SCHAFFENSTAR_ELDER_ADAUX");
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(156123, "Schaffenstar Member", "d_startower_90", 561, 2175, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_01");
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(156124, "Schaffenstar Member", "d_startower_90", 617, 2180, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_02");
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(156125, "Schaffenstar Member", "d_startower_90", 680, 2182, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_03");
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(156126, "Schaffenstar Member", "d_startower_90", 587, 2205, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_04");
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(156127, "Schaffenstar Member", "d_startower_90", 645, 2224, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_05");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156126, "Resistance Soldier", "d_startower_90", 512, 1979, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_04");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155165, "Resistance Soldier", "d_startower_90", 553, 1947, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_05");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(156127, "Resistance Soldier", "d_startower_90", 509, 1917, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_06");
		
		// Second Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(153137, "Second Defensive Device", "d_startower_90", 1842, 913, 180, "D_STARTOWER_90_2ND_DEFENCE_DEVICE");
		
		// First Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(153137, "First Defensive Device", "d_startower_90", -722, -1499, 180, "D_STARTOWER_90_1ST_DEFENCE_DEVICE");
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(151006, "Transparency Controls", "d_startower_90", 1415, -1521, 180, "D_STARTOWER_90_1ST_HIDE_CONTROL_DEVICE");
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(151006, "Transparency Controls", "d_startower_90", 778, -1431, 180, "D_STARTOWER_90_2ND_HIDE_CONTROL_DEVICE");
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(151006, "Transparency Controls", "d_startower_90", 264, -1527, 180, "D_STARTOWER_90_3RD_HIDE_CONTROL_DEVICE");
		
		// Statue of Goddess Laima
		//-------------------------------------------------------------------------
		AddNpc(40100, "Statue of Goddess Laima", "d_startower_90", -1261, 158, 90, "D_STARTOWER_90_STATUE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_90", 1812, -906, 90, "", "D_STARTOWER_90_MQ_10_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20045, " ", "d_startower_90", 56, 1003, 87, "D_STARTOWER_90_MQ_HIDDENWALL", "D_STARTOWER_90_MQ_HIDDENWALL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_90", -324, 151, 90, "", "D_STARTOWER_90_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_90", -713.5576, -1037.372, 90, "", "D_STARTOWER_90_MQ_30_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_90", 112, 448, 90, "", "D_STARTOWER_90_MQ_60_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154066, " ", "d_startower_90", 56, 996, 90, "D_STARTOWER_90_MQ_HIDDENWALL_TRIGGER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 1419, -1379, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 808, -1426, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 269, -1450, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -716, -1469, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -713, -910, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 248, -932, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 978, -894, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 62, -354, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 786, 163, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 132, 255, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 1788, 894, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 1254, 1201, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 121, 1942, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -458, 1876, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -1399, 736, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -761, 761, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 640, 1175, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -330, 1242, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -1142, 1343, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 1420.143, -1380.3, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 796.5229, -1436.854, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 277.7894, -1447.742, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -732.1516, -1487.259, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -672.809, -890.9528, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 116.3271, -542.799, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 770.9013, -938.5419, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", -309.6108, 162.2018, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 247.8276, 155.4086, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_90", 839.2718, 123.2209, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
	}
}
