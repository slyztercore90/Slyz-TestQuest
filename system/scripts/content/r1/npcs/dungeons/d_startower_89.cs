//--- Melia Script ----------------------------------------------------------
// Astral Tower 4F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 4F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower89NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 1F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 1F", "d_startower_89", 1230, -1978, -70, "", "D_STARTOWER_89_TO_D_STARTOWER_88", "");
		
		// Astral Tower 12F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Astral Tower 12F", "d_startower_89", 188, -521, 270, "", "D_STARTOWER_89_TO_D_STARTOWER_90", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_89", 1301, -1893, 45, "D_STARTOWER_89_RESISTANCE_LEADER_BAYL_01");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_89", 221.9301, -829.4982, 90, "D_STARTOWER_89_RESISTANCE_LEADER_BAYL_02");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155163, "Resistance Soldier", "d_startower_89", 124, -701, 90, "D_STARTOWER_89_RESISTANCE_MEMBER_01");
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(156133, "Resistance Adjutant", "d_startower_89", 202, -681, 0, "D_STARTOWER_89_RESISTANCE_MEMBER_02");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(155164, "Resistance Soldier", "d_startower_89", 174, -750, 180, "D_STARTOWER_89_RESISTANCE_MEMBER_03");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_89", 373, 2102, 45, "D_STARTOWER_89_RESISTANCE_LEADER_BAYL_03");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(156120, "Resistance Commander Byle", "d_startower_89", -253, -37, 90, "D_STARTOWER_89_RESISTANCE_LEADER_BAYL_04");
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(156117, "Resistance Adjutant", "d_startower_89", 68, 94, 90, "D_STARTOWER_89_RESISTANCE_MEMBER_04");
		
		// Proud Soldier
		//-------------------------------------------------------------------------
		AddNpc(156127, "Proud Soldier", "d_startower_89", 126, 129, 0, "D_STARTOWER_89_RESISTANCE_MEMBER_05");
		
		// Sighing Soldier
		//-------------------------------------------------------------------------
		AddNpc(156124, "Sighing Soldier", "d_startower_89", 130, 53, 180, "D_STARTOWER_89_RESISTANCE_MEMBER_06");
		
		// Medic
		//-------------------------------------------------------------------------
		AddNpc(155165, "Medic", "d_startower_89", -156, -186, 90, "D_STARTOWER_89_RESISTANCE_MEMBER_07");
		
		// Injured Soldier
		//-------------------------------------------------------------------------
		AddNpc(155164, "Injured Soldier", "d_startower_89", -134.7324, -183.0325, 0, "D_STARTOWER_89_RESISTANCE_MEMBER_08");
		
		// First Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(153137, "First Defensive Device", "d_startower_89", 146, -842, 180, "D_STARTOWER_89_1ST_DEFENCE_DEVICE");
		
		// Second Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(153137, "Second Defensive Device", "d_startower_89", 468, 2038, 180, "D_STARTOWER_89_2ND_DEFENCE_DEVICE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_89", 527, -846, 90, "", "D_STARTOWER_89_MQ_20_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_89", 765, 1114, 90, "", "D_STARTOWER_89_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_startower_89", 94, 1927, 90, "", "D_STARTOWER_89_MQ_60_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_startower_89", -554, -260, 90, "", "D_STARTOWER_89_MQ_80_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1466, -1565, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 707, -862, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1354, -847, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 718, -78, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 810, 892, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -22, 727, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -455, 1629, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -117, 1091, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -737, 860, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -924, -117, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -538, -273, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -1191, 646, 90, "", "STARTOWER_89_ARROWRAIN_TRAP", "STARTOWER_89_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1307, -1141, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1351.05, -1138.74, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1048.943, -895.1771, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1048.453, -850.9902, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 1048.024, -808.4247, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 695.441, -560.5107, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 737.1693, -638.3681, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 413.8186, -892.1843, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 713.2956, -601.6901, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 439.286, -848.7277, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 411.6418, -808.5316, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 387.1287, 766.2966, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 746.0699, 428.9463, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 709.1535, 428.4358, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", 420.6641, 740.2083, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -140.0037, 881.0236, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -114.6446, 921.6643, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -157.2098, 952.0253, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -352.6847, 1519.416, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -211.3617, 1717.774, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -250.6408, 1688.133, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -474.673, 1061.312, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -1047.23, 580.8422, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -1007.129, 539.4123, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -963.8016, -58.40914, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -937.412, -113.0729, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -917.3733, -45.47331, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -524.0596, 212.8982, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "d_startower_89", -485.8332, 187.7208, 90, "", "STARTOWER_89_POISON_TRAP", "");
		
		// Elder Henika
		//-------------------------------------------------------------------------
		AddNpc(156135, "Elder Henika", "d_startower_89", -307, 95, 45, "D_STARTOWER_89_SCHAFFENSTAR_ELDER_HENIKA");
		
		// Lookout Soldier
		//-------------------------------------------------------------------------
		AddNpc(150180, "Lookout Soldier", "d_startower_89", -262, 113, 270, "D_STARTOWER_89_RESISTANCE_MEMBER_09");
	}
}
