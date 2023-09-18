//--- Melia Script ----------------------------------------------------------
// Miners' Village
//--- Description -----------------------------------------------------------
// NPCs found in and around Miners' Village.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliaiOutNpcScript : GeneralScript
{
	public override void Load()
	{
		// Crystal Mine
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine", "f_siauliai_out", -213, -17, -75, "", "WS_ACT3_ACT4_1", "");
		
		// Srautas Gorge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Srautas Gorge", "f_siauliai_out", 1832, -578, 85, "", "SIALLAIOUT_GELE571", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_siauliai_out", 190.5049, -1214.24, 0, "WARP_F_SIAULIAI_OUT", "STOUP_CAMP", "STOUP_CAMP");
		
		// Hidden house of Krivis
		//-------------------------------------------------------------------------
		AddNpc(20025, "Hidden house of Krivis", "f_siauliai_out", -142.9346, -221.0289, 90, "JOB_KRIWI1_OUT");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1086, -1522, 175, "SIAULIAIOUT_119_2");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1197, -1627, 175, "SIAULIAIOUT_119_3");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1237, -1457, 175, "SIAULIAIOUT_119_4");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1160, -1225, 175, "SIAULIAIOUT_119_5");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1364, -1002, 175, "SIAULIAIOUT_119_6");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1576.49, -1673.1, 175, "SIAULIAIOUT_119_7");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -1807, -1853, 175, "SIAULIAIOUT_119_8");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(46212, "Relief Box", "f_siauliai_out", -2078.32, -1782.61, 181, "SIAULIAIOUT_119_9");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10033, " ", "f_siauliai_out", -1901, -1414, 90, "", "SIAULIAIOUT_RETUA", "");
		
		// Healer Lady
		//-------------------------------------------------------------------------
		AddNpc(20168, "Healer Lady", "f_siauliai_out", -1913, -1428, 136, "SIAULIAIOUT_HEALER_B");
		
		// Healer Lady
		//-------------------------------------------------------------------------
		AddNpc(20168, "Healer Lady", "f_siauliai_out", -1913, -1428, -55, "SIAULIAIOUT_HEALER_C");
		
		// SIAULIAIOUTQ01
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTQ01", "f_siauliai_out", 506, -1622, 0, "", "SIAULIAIOUT_Q01", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(45315, "Kepa Wagon", "f_siauliai_out", -82, -612, 61, "", "SIAULIAIOUT_CART", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(45315, "Kepa Wagon", "f_siauliai_out", -41, -608, 0, "", "SIAULIAIOUT_CART", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(45315, "Kepa Wagon", "f_siauliai_out", -64, -557, 0, "", "SIAULIAIOUT_CART", "");
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(20109, "Mine Manager Brinker", "f_siauliai_out", -1758.601, -813.7792, 270, "SIAULIAIOUT_MINER_B");
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(20109, "Mine Manager Brinker", "f_siauliai_out", 355, -1117, 0, "SIAULIAIOUT_MINER_A");
		
		// Miners' Village Mayor
		//-------------------------------------------------------------------------
		AddNpc(20118, "Miners' Village Mayor", "f_siauliai_out", -87.64736, -802.0891, 90, "SIAULIAIOUT_CHIEF_A");
		
		// SIAULIAIOUT_MIRTIS
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUT_MIRTIS", "f_siauliai_out", 1900, 130, 90, "", "SIAULIAIOUT_MIRTIS", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(20110, "[Alchemist Master]{nl}Vaidotas", "f_siauliai_out", 1309.119, 331.726, 4, "SIAULIAIOUT_ALCHE");
		
		// SIAULIAIOUTALCHE
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTALCHE", "f_siauliai_out", 1298, 307, 90, "", "SIAULIAIOUT_PREAL", "");
		
		// SIAULIAIOUTBOSS
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTBOSS", "f_siauliai_out", 1434, 535, 90, "", "SIAULIAIOUT_BOSS", "");
		
		// SIAULIAIOUTQ03
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTQ03", "f_siauliai_out", -468, -1514, 90, "", "SIAULIAIOUT_Q03", "");
		
		// Hunter
		//-------------------------------------------------------------------------
		AddNpc(47245, "Hunter", "f_siauliai_out", -945, -1812, 90, "SIAULIAIOUT_HUNTER");
		
		// SIAULIAIOUTQ06
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTQ06", "f_siauliai_out", -1143, -1248, 90, "", "SIAULIAIOUT_Q06", "");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1749, -1110, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1704, -1248, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1591, -1208, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1514, -1323, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1426, -1163, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1229, -1099, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1186, -975, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1090, -1151, 90, "SIAULIAIOUT_STONE");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(10043, "Reinforcement Stone", "f_siauliai_out", -1560, -826, 90, "SIAULIAIOUT_STONE");
		
		// SIAULIAIOUTQ11
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTQ11", "f_siauliai_out", 828, -931, 90, "", "SIAULIAIOUT_Q11", "");
		
		// SIAULIAIOUTQ12
		//-------------------------------------------------------------------------
		AddNpc(20026, "SIAULIAIOUTQ12", "f_siauliai_out", 1377, -455, 90, "", "SIAULIAIOUT_Q12", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(20110, "[Alchemist Master]{nl}Vaidotas", "f_siauliai_out", -38.88, -1021.81, 90, "SIAULIAIOUT_ALCHE_A", "SIAULIAIOUT_ALCHE_A");
		
		// Wagon Explosion
		//-------------------------------------------------------------------------
		AddNpc(40095, "Wagon Explosion", "f_siauliai_out", -61, -656, 90, "SIAULIAIOUT_BLOCK");
		
		// SOUT_SUDD
		//-------------------------------------------------------------------------
		AddNpc(20026, "SOUT_SUDD", "f_siauliai_out", -1531.77, -1751.32, 90, "", "SOUT_SUDD", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_siauliai_out", 1911, 75, 90, "", "JOB_HUNTER2_1_TRIGGER", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_siauliai_out", 57, -133, 90, "", "JOB_HUNTER2_3_TRIGGER", "");
		
		// Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Notice", "f_siauliai_out", -142, -435, 90, "F_SIAULIA_OUT_BOARD01");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_siauliai_out", 49, -1038, 90, "", "JOB_PRIEST2_1_TRIGGER", "");
		
		// Village Aunt
		//-------------------------------------------------------------------------
		AddNpc(20114, "Village Aunt", "f_siauliai_out", -54, -1064, 90, "F_SIAU_OUT_NPC01");
		
		// Miner
		//-------------------------------------------------------------------------
		AddNpc(20150, "Miner", "f_siauliai_out", 36, -968, 90, "F_SIAU_OUT_NPC02");
		
		// Village Girl
		//-------------------------------------------------------------------------
		AddNpc(147473, "Village Girl", "f_siauliai_out", 66, -1083, 90, "F_SIAU_OUT_NPC03");
		
		// Lot 2 Closure Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Lot 2 Closure Notice", "f_siauliai_out", 129, -18, 360, "F_SIAULIAI_OUT_BOARD02");
		
		// [Psychokino Submaster]{nl}Cielle Gudan
		//-------------------------------------------------------------------------
		AddNpc(155072, "[Psychokino Submaster]{nl}Cielle Gudan", "f_siauliai_out", 554.1078, -879.4257, 45, "JOB_PSYCHOKINESIST2_1_NPC");
		
		// [Linker Submaster]{nl}Roddie Kuska
		//-------------------------------------------------------------------------
		AddNpc(155073, "[Linker Submaster]{nl}Roddie Kuska", "f_siauliai_out", 312, -1010, -40, "JOB_LINKER2_1_NPC");
		
		// JOB_PSYCHOKINESIST4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_PSYCHOKINESIST4_1_TRIGGER", "f_siauliai_out", 1463.91, 478.93, 90, "", "JOB_PSYCHOKINESIST4_1_TRIGGER", "");
		
		// Hidden trigger for 5th advancement Psychokino_Linker_Alchemist
		//-------------------------------------------------------------------------
		AddNpc(20026, "Hidden trigger for 5th advancement Psychokino_Linker_Alchemist", "f_siauliai_out", -2108.24, -1829.4, 121, "", "JOB_SPYLIAL5_1_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_out", 1651.87, 427.34, 90, "TREASUREBOX_BUBE");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "f_siauliai_out", -2194, -2055, 84, "F_SIAULIAI_OUT_EV_55_001", "F_SIAULIAI_OUT_EV_55_001", "F_SIAULIAI_OUT_EV_55_001");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_siauliai_out", 83.14928, -1082.023, 90, "", "JOB_CLERIC2_2_TRIGGER", "");
		
		// Refugee
		//-------------------------------------------------------------------------
		AddNpc(152000, "Refugee", "f_siauliai_out", -2242.07, -1971.59, 72, "SOUT_REFUGEE01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152000, " ", "f_siauliai_out", -1958.963, -1449.023, 72, "SOUT_REFUGEE01_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152001, " ", "f_siauliai_out", -1935.062, -1467.271, 135, "SOUT_REFUGEE02_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152001, " ", "f_siauliai_out", -2266.51, -1973.57, -18, "SOUT_REFUGEE02");
		
		// Safety Instructions
		//-------------------------------------------------------------------------
		AddNpc(40070, "Safety Instructions", "f_siauliai_out", -58, -133, 45, "F_SIAULIAI_OUT_BOARD03");
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(20109, "Mine Manager Brinker", "f_siauliai_out", -1758.601, -813.7792, 15, "SIAULIAIOUT_MINER_C");
		
		// Pharmacist Lady
		//-------------------------------------------------------------------------
		AddNpc(147493, "Pharmacist Lady", "f_siauliai_out", -47.84776, -1212.506, 90, "SOUT_PHARMACY");
		
		// Soldier Jace
		//-------------------------------------------------------------------------
		AddNpc(20016, "Soldier Jace", "f_siauliai_out", 90.9569, -1225.092, 90, "SIAULIAIOUT_SOLDIRE_SQ31");
		
		// Soldier Edgar
		//-------------------------------------------------------------------------
		AddNpc(20019, "Soldier Edgar", "f_siauliai_out", 429.0146, -1201.718, 90, "SIAULIAIOUT_SOLDIRE_SQ32");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20045, "", "f_siauliai_out", -60.96616, -605.2911, 90, "", "SOUT_Q_16_WALL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47252, " ", "f_siauliai_out", 323.6613, -190.6289, 27, "SIAU_HUAN_MNT");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_siauliai_out", 1224.35, 279.95, 90, "TREASUREBOX_LV_F_SIAULIAI_OUT10054");
		
		// Lens of the Stars [Quarrel Shooter Advancement]
		//-------------------------------------------------------------------------
		AddNpc(20026, "Lens of the Stars [Quarrel Shooter Advancement]", "f_siauliai_out", -73.10419, -209.0591, 90, "", "JOB_QUARRELSHOOTER1_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_siauliai_out", 1534.596, 221.9166, 90, "", "EXPLORER_MISLE3", "");
	}
}
