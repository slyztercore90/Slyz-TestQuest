//--- Melia Script ----------------------------------------------------------
// Ramstis Ridge
//--- Description -----------------------------------------------------------
// NPCs found in and around Ramstis Ridge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FRokas25NpcScript : GeneralScript
{
	public override void Load()
	{
		// Gateway of the Great King
		//-------------------------------------------------------------------------
		AddNpc(40001, "Gateway of the Great King", "f_rokas_25", -2368, -1192, -49, "", "ROKAS25_ROKAS24", "");
		
		// Overlong Bridge Valley
		//-------------------------------------------------------------------------
		AddNpc(40001, "Overlong Bridge Valley", "f_rokas_25", 2769, -1105, 90, "", "ROKAS25_ROKAS26", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(47101, "", "f_rokas_25", 2011, -227, 30, "", "ROKAS25_ZACHARIEL32_NPC", "");
		
		// Sanctum
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sanctum", "f_rokas_25", 2049, -286, 210, "", "ROKAS25_ZACHARIEL32", "");
		
		// Sanctum's First Seal
		//-------------------------------------------------------------------------
		AddNpc(47102, "Sanctum's First Seal", "f_rokas_25", -1941, 912, 53, "ROKAS25_SWITCH1", "ROKAS25_SWITCH1");
		
		// 1st Disciple of Gustas
		//-------------------------------------------------------------------------
		AddNpc(20118, "1st Disciple of Gustas", "f_rokas_25", -2300, -421, 53, "ROKAS25_REXIPHER2");
		
		// Bramble
		//-------------------------------------------------------------------------
		AddNpc(20041, "Bramble", "f_rokas_25", -252.03, 572.88, 53, "", "ROKAS25_REXIPHER2_MBOSS", "");
		
		// 2nd Disciple of Gustas
		//-------------------------------------------------------------------------
		AddNpc(20139, "2nd Disciple of Gustas", "f_rokas_25", 441.63, 241.4, 53, "ROKAS25_REXIPHER3");
		
		// Sanctum's Second Seal
		//-------------------------------------------------------------------------
		AddNpc(47102, "Sanctum's Second Seal", "f_rokas_25", 1080, -200, 53, "ROKAS25_SWITCH3", "ROKAS25_SWITCH3");
		
		// Mercenary Toby
		//-------------------------------------------------------------------------
		AddNpc(20117, "Mercenary Toby", "f_rokas_25", -1964, -469, 0, "ROKAS25_SUB1");
		
		// Device
		//-------------------------------------------------------------------------
		AddNpc(47102, "Device", "f_rokas_25", 2096, 393, 53, "ROKAS25_SWITCH4", "ROKAS25_SWITCH4");
		
		// Sanctum's Third Seal
		//-------------------------------------------------------------------------
		AddNpc(47102, "Sanctum's Third Seal", "f_rokas_25", 1612, -1072, 53, "ROKAS25_SWITCH5");
		
		// Device
		//-------------------------------------------------------------------------
		AddNpc(47102, "Device", "f_rokas_25", 2513, -1065, 53, "ROKAS25_SWITCH6");
		
		// Molding Pot
		//-------------------------------------------------------------------------
		AddNpc(40064, "Molding Pot", "f_rokas_25", 205, 805, -21, "ROKAS25_CALDRON1");
		
		// Kevin
		//-------------------------------------------------------------------------
		AddNpc(20150, "Kevin", "f_rokas_25", -1017, 418, 90, "ROKAS25_KEBIN");
		
		// Vincent
		//-------------------------------------------------------------------------
		AddNpc(20138, "Vincent", "f_rokas_25", 190.83, 762.95, 90, "ROKAS25_BINSENT");
		
		// Sculptor Hilda
		//-------------------------------------------------------------------------
		AddNpc(20139, "Sculptor Hilda", "f_rokas_25", -1828, -567, 6, "ROKAS25_HILDA1");
		
		// Sculptor Hilda
		//-------------------------------------------------------------------------
		AddNpc(20139, "Sculptor Hilda", "f_rokas_25", -805.3795, 836.4071, 90, "ROKAS25_HILDA2");
		
		// Sculptor Hilda
		//-------------------------------------------------------------------------
		AddNpc(20139, "Sculptor Hilda", "f_rokas_25", 32.68515, 382.9095, 90, "ROKAS25_HILDA3");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -1444.693, 675.0276, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -1264.733, 541.1766, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -1306.234, 689.8638, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -642.8182, 760.1284, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -921.6347, 863.0478, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -478.5173, 447.8148, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -1110.702, 700.9824, 90, "ROKAS25_FIREWOOD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46011, " ", "f_rokas_25", -1209, 692, 90, "ROKAS25_FIREWOOD");
		
		// Molding Pot
		//-------------------------------------------------------------------------
		AddNpc(40064, "Molding Pot", "f_rokas_25", 249.27, 799.52, 10, "ROKAS25_CALDRON2");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -1911.329, -1097.921, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -2151.335, -1180.065, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -2006.67, -776.8724, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -2384.875, -1011.537, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -2437.097, -664.1481, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -2321.537, -796.3264, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -1622, -905, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Abandoned Graverobbing Equipment
		//-------------------------------------------------------------------------
		AddNpc(47160, "Abandoned Graverobbing Equipment", "f_rokas_25", -1739.484, -1144.729, 90, "ROKAS25_EX2_STRUCTURE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -803, 856, 177, "ROKAS25_HILDA_STRUCTURE");
		
		// Gustas Jonas
		//-------------------------------------------------------------------------
		AddNpc(147390, "Gustas Jonas", "f_rokas_25", 1985, -328, 90, "ROKAS25_REXIPHER5");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -722, 428, 90, "ROKAS25_HILDA_STRUCTURE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -1155.105, 782.3403, 90, "ROKAS25_HILDA_STRUCTURE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -489, 735, 90, "ROKAS25_HILDA_STRUCTURE");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "f_rokas_25", 677.9764, 770.3821, 90, "ROKAS_25_HQ01_NPC01");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "f_rokas_25", 1720.165, 77.56188, 90, "ROKAS_25_HQ01_NPC02");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "f_rokas_25", 1399.872, -837.1577, 90, "ROKAS_25_HQ01_NPC03");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "f_rokas_25", 1946.991, 634.7874, 90, "ROKAS_25_HQ01_NPC04");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10045, " ", "f_rokas_25", -457, 651, 90, "ROKAS25_REXIPHER2_BOSS_STONE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -916.8253, 343.9211, 90, "ROKAS25_HILDA_STRUCTURE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -1399.118, 702.1993, 90, "ROKAS25_HILDA_STRUCTURE");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -1054.135, 823.9144, 90, "ROKAS25_HILDA_STRUCTURE_TRUE1");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -527.148, 413.0995, 90, "ROKAS25_HILDA_STRUCTURE_TRUE2");
		
		// Ancient Pillars
		//-------------------------------------------------------------------------
		AddNpc(47106, "Ancient Pillars", "f_rokas_25", -50.87834, 661.1926, 90, "ROKAS25_HILDA_STRUCTURE_TRUE3");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_rokas_25", 818.0075, 1171.682, 90, "", "JOB_PYROMANCER3_1_TRIGGER", "");
		
		// 1 sheet of Magic Research Reference 
		//-------------------------------------------------------------------------
		AddNpc(147312, "1 sheet of Magic Research Reference ", "f_rokas_25", -1908.255, 572.5779, 90, "JOB_THAUMATURGE3_1_PAPER1");
		
		// 2 sheet of Magic Research Reference 
		//-------------------------------------------------------------------------
		AddNpc(147312, "2 sheet of Magic Research Reference ", "f_rokas_25", -2061.47, 574.3754, 90, "JOB_THAUMATURGE3_1_PAPER2");
		
		// 3 sheet of Magic Research Reference 
		//-------------------------------------------------------------------------
		AddNpc(147312, "3 sheet of Magic Research Reference ", "f_rokas_25", -2128.05, 637.8066, 90, "JOB_THAUMATURGE3_1_PAPER3");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_25", -2482.46, -913.39, 90, "TREASUREBOX_LV_F_ROKAS_25679");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_rokas_25", -686.0457, 834.3984, 90, "", "EXPLORER_MISLE27", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "f_rokas_25", -2085.914, 347.8569, 90, "", "JOB_ASSASSIN_Q1_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_25", 1111.726, 1219.251, -50, "TREASUREBOX_LV_F_ROKAS_25682");
	}
}
