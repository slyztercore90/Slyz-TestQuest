//--- Melia Script ----------------------------------------------------------
// West Siauliai Woods
//--- Description -----------------------------------------------------------
// NPCs found in and around West Siauliai Woods.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliaiWestNpcScript : GeneralScript
{
	public override void Load()
	{
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(10032, "Scout", "f_siauliai_west", -1121, -528, -9, "SIALUL_WEST_DRASIUS");
		
		// Search Scout
		//-------------------------------------------------------------------------
		AddNpc(41206, "Search Scout", "f_siauliai_west", -1488, -138, 0, "SIAUL_WEST_NAGLIS2", "SIAUL_WEST_NAGLIS2", "SIAUL_WEST_NAGLIS2");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_siauliai_west", -525, -435, 0, "WARP_F_SIAULIAI_WEST", "STOUP_CAMP", "STOUP_CAMP");
		
		// Knight Titas
		//-------------------------------------------------------------------------
		AddNpc(20107, "Knight Titas", "f_siauliai_west", -576, -719, 254, "SIAUL_WEST_CAMP_MANAGER");
		
		// Laimonas
		//-------------------------------------------------------------------------
		AddNpc(20117, "Laimonas", "f_siauliai_west", 326.5086, -346.8529, 0, "SIAUL_WEST_LAIMONAS");
		
		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(20016, "Sentinel", "f_siauliai_west", -652, -953, 0, "SIAU_FRON_NPC_01");
		
		// Klaipeda Resident
		//-------------------------------------------------------------------------
		AddNpc(20114, "Klaipeda Resident", "f_siauliai_west", -624, -385, 7, "SIAUL_WEST_RESIDENT1");
		
		// Laimonas 1 Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Laimonas 1 Trigger", "f_siauliai_west", 773, -125, 90, "", "SIAUL_WEST_LAIMONAS1_TRIGGER", "SIAUL_WEST_LAIMONAS1_TRIGGER");
		
		// Laimonas 2 Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Laimonas 2 Trigger", "f_siauliai_west", 980, 559, 90, "", "SIAUL_WEST_LAIMONAS2_TRIGGER", "");
		
		// Siauliai Guard
		//-------------------------------------------------------------------------
		AddNpc(10022, "Siauliai Guard", "f_siauliai_west", -851, -495, -59, "F_SIAUL_GAURD");
		
		// Klaipeda Guard
		//-------------------------------------------------------------------------
		AddNpc(10032, "Klaipeda Guard", "f_siauliai_west", 1651, -706, -19, "SIAUL_ST1_ST2_GAURD");
		
		// Klaipeda Guard Captain
		//-------------------------------------------------------------------------
		AddNpc(20019, "Klaipeda Guard Captain", "f_siauliai_west", 1626, -798, 270, "SIAUL_ST1_ST2");
		
		// Chase Trigger of Hanaming
		//-------------------------------------------------------------------------
		AddNpc(20041, "Chase Trigger of Hanaming", "f_siauliai_west", -403, 363, 90, "", "SIAUL_WEST_HANAMING_TRIGGER", "");
		
		// Klaipeda Guard
		//-------------------------------------------------------------------------
		AddNpc(10032, "Klaipeda Guard", "f_siauliai_west", 1650, -854, 195, "SIAUL_WEST_SOLDIER3");
		
		// SIAUL_WEST_ADD_SUB_01
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAUL_WEST_ADD_SUB_01", "f_siauliai_west", -443, 120, 90, "", "SIAUL_WEST_ADD_SUB_01", "");
		
		// SIAUL_WEST_LAIMONAS3_2
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAUL_WEST_LAIMONAS3_2", "f_siauliai_west", 1565.729, 327.5524, 90, "", "SIAUL_WEST_LAIMONAS3_2_TRIGGER", "");
		
		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10032, "Sentinel", "f_siauliai_west", -626, -757, 176, "SIAU_FRON_NPC_04");
		
		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10032, "Sentinel", "f_siauliai_west", -619, -707, 16, "SIAU_FRON_NPC_05");
		
		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10032, "Sentinel", "f_siauliai_west", -509, -821, 251, "SIAU_FRON_NPC_03");
		
		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10032, "Sentinel", "f_siauliai_west", -589, -822, 90, "SIAU_FRON_NPC_02");
		
		// Start Trigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "Start Trigger", "f_siauliai_west", -560, -780, 90, "", "SIAUL_WEST_MEET_TITAS_AUTO", "");
		
		// Battle Commander
		//-------------------------------------------------------------------------
		AddNpc(20016, "Battle Commander", "f_siauliai_west", -663, 503, 90, "SIAUL_WEST_SOL3");
		
		// Medium Boss Golem Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Medium Boss Golem Trigger", "f_siauliai_west", -550, 1370, 0, "", "SIAUL_WEST_BOSS_GOLEM_TRIGGER", "");
		
		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Large Kepa Trigger", "f_siauliai_west", -2005, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");
		
		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Large Kepa Trigger", "f_siauliai_west", -1765, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");
		
		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Large Kepa Trigger", "f_siauliai_west", -1845, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");
		
		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Large Kepa Trigger", "f_siauliai_west", -1925, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40080, "Warning", "f_siauliai_west", -1566, -1096, 8, "SIAUL1_BOARD2");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40080, "Warning", "f_siauliai_west", -1692, -150, 4, "SIAUL1_BOARD3");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "f_siauliai_west", 487, -139, 40, "SIAUL1_BOARD4");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40080, "Warning", "f_siauliai_west", -572, 449, 182, "SIAUL1_BOARD5");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "f_siauliai_west", -695, 840, 26, "SIAUL1_BOARD6");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "f_siauliai_west", -547, -453, -3, "SIAUL1_BOARD7");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40070, "", "f_siauliai_west", -1822, -925, 405, "SIAUL1_BOARDCRYSTAL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_siauliai_west", 175, 384, 90, "", "JOB_SAPPER2_1_TRIGGER", "");
		
		// [Hoplite Submaster]{nl}Vysiege Thurmore
		//-------------------------------------------------------------------------
		AddNpc(155065, "[Hoplite Submaster]{nl}Vysiege Thurmore", "f_siauliai_west", -331, -400, 0, "JOB_HOPLITE2_NPC");
		
		// For Krivis' 4th advancement quest track
		//-------------------------------------------------------------------------
		AddNpc(20026, "For Krivis' 4th advancement quest track", "f_siauliai_west", 1505.41, -778.63, 90, "", "JOB_KRIVI4_2_TRACK", "");
		
		// JOB_WIZARD4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_WIZARD4_1_TRIGGER", "f_siauliai_west", -595.97, 1356.17, 90, "", "JOB_WIZARD4_1_TRIGGER", "");
		
		// JOB_CRYOMANCER4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_CRYOMANCER4_1_TRIGGER", "f_siauliai_west", 1697.45, 387.61, 90, "", "JOB_CRYOMANCER4_1_TRIGGER", "");
		
		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Soldier Recruitment Notice", "f_siauliai_west", 1615.97, -713.26, -7, "SIAUL_WEST_HQ01_INFO01");
		
		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Soldier Recruitment Notice", "f_siauliai_west", -558.6, -1021.28, 269, "SIAUL_WEST_HQ01_INFO02");
		
		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Soldier Recruitment Notice", "f_siauliai_west", -1277.39, -614.18, 90, "SIAUL_WEST_HQ01_INFO03");
		
		// Klaipeda Officer
		//-------------------------------------------------------------------------
		AddNpc(147416, "Klaipeda Officer", "f_siauliai_west", 1553.76, -695.25, 90, "TUTO_SKIP_NPC");
		
		// Rocktortuga Spawn Trigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "Rocktortuga Spawn Trigger", "f_siauliai_west", 1428.38, -922.82, 90, "", "SIAUL_WEST_ROCK", "");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(20026, "Statue of Goddess Zemyna", "f_siauliai_west", 1705.19, 390.19, 90, "", "SIAUL_WEST_LAIMONAS3_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_west", 1564, -370, 270, "TREASUREBOX_LV_F_SIAULIAI_WEST2027");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "f_siauliai_west", 1687, 366, 20, "F_SIAULIAI_WEST_EV_55_001", "F_SIAULIAI_WEST_EV_55_001", "F_SIAULIAI_WEST_EV_55_001");
		
		// West Siauliai Woods
		//-------------------------------------------------------------------------
		AddNpc(40001, "West Siauliai Woods", "f_siauliai_west", 2755.275, 443.1412, -24, "", "SIAULIAI_WEST_OUT_OF_SECRET", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_west", -580, -1417, 180, "TREASUREBOX_LV_F_SIAULIAI_WEST2032");
		
		// [Dievdirbys Master]{nl}Sculptor Tesla
		//-------------------------------------------------------------------------
		AddNpc(47239, "[Dievdirbys Master]{nl}Sculptor Tesla", "f_siauliai_west", -751.0155, -362.2574, 0, "JOB_DIEVDIRBYS2_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(47248, "", "f_siauliai_west", -778.9161, -353.6469, 0, "JOB_DIEVDIRBYS3_3_NPC");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_west", -2004.07, -940.17, 0, "TREASUREBOX_LV_F_SIAULIAI_WEST2034");
		
		// Lv3 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147393, "Lv3 Treasure Chest", "f_siauliai_west", 185.81, -856.9, 90, "TREASUREBOX_LV_F_SIAULIAI_WEST2035");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_west", 1346.05, -1087.24, 90, "TREASUREBOX_LV_F_SIAULIAI_WEST2036");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_siauliai_west", 3221.666, 865.9946, 90, "RUNECASTER_SIAULIAI_WEST_STONE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_siauliai_west", -2067.653, -1273.606, 90, "", "EXPLORER_MISLE1", "");
	}
}
