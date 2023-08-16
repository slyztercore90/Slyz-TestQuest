//--- Melia Script ----------------------------------------------------------
// Gytis Settlement Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Gytis Settlement Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliai501NpcScript : GeneralScript
{
	public override void Load()
	{
		// Baron Allerno
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Baron Allerno", "f_siauliai_50_1", -794.7111, -43.9683, 1714.197, 157, "", "SIAUL50_1_TO_FARM_47_4", "");
		
		// Gytis
		//-------------------------------------------------------------------------
		AddNpc(2, 20154, "Gytis", "f_siauliai_50_1", 99.45765, 0.2093, -362.8868, -17, "SIAULIAI_50_1_SQ_GYTIS", "", "");
		
		// Researcher Gareth
		//-------------------------------------------------------------------------
		AddNpc(3, 147484, "Researcher Gareth", "f_siauliai_50_1", -10.28792, 0.2093, -365.3172, -28, "SIAULIAI_50_1_SQ_RESEARCHER", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 47203, " ", "f_siauliai_50_1", -1143.512, 0.2093, -1374.933, 90, "SIAULIAI_50_1_SQ_GRASS", "SIAULIAI_50_1_GRASS_MESSAGE", "");
		
		// Soldier Dennis
		//-------------------------------------------------------------------------
		AddNpc(5, 20016, "Soldier Dennis", "f_siauliai_50_1", -97.32806, 0.2093, -491.4406, 69, "SIAULIAI_50_1_SQ_SOLDIER01", "", "");
		
		// Soldier Alan
		//-------------------------------------------------------------------------
		AddNpc(6, 10037, "Soldier Alan", "f_siauliai_50_1", -1053.699, -209.7028, 553.2155, 90, "SIAULIAI_50_1_SQ_SOLDIER02", "", "");
		
		// Soldier Peirce
		//-------------------------------------------------------------------------
		AddNpc(7, 20019, "Soldier Peirce", "f_siauliai_50_1", -1885.54, -209.7, 27.54, 90, "SIAULIAI_50_1_SQ_SOLDIER03", "", "");
		
		// Louise
		//-------------------------------------------------------------------------
		AddNpc(8, 20118, "Louise", "f_siauliai_50_1", 1270.175, 22.2216, 432.7068, 90, "SIAULIAI_50_1_SQ_MAN01", "", "");
		
		// Klaipeda
		//-------------------------------------------------------------------------
		AddNpc(9, 40001, "Klaipeda", "f_siauliai_50_1", 1638.162, 0.2093, -1425.22, 119, "", "SIAUL50_1_TO_KLAPEDA", "");
		
		// Veja Ravine
		//-------------------------------------------------------------------------
		AddNpc(10, 40001, "Veja Ravine", "f_siauliai_50_1", 2333.833, 22.2216, 536.9122, 90, "", "SIAUL50_1_TO_HUEVILLAGE_58_1", "");
		
		// Vieta Gorge
		//-------------------------------------------------------------------------
		AddNpc(11, 40001, "Vieta Gorge", "f_siauliai_50_1", 905.0521, -43.9683, 1758.891, 170, "", "SIAUL50_1_TO_HUEVILLAGE_58_2", "");
		
		// Soldier Peirce
		//-------------------------------------------------------------------------
		AddNpc(16, 20019, "Soldier Peirce", "f_siauliai_50_1", -247.7353, 0.2093, -314.5381, 62, "SIAULIAI_50_1_SQ_SOLDIER03_AFTER", "", "");
		
		// Soldier Gatus
		//-------------------------------------------------------------------------
		AddNpc(17, 20015, "Soldier Gatus", "f_siauliai_50_1", 67.28238, 0.2093, -502.2321, 190, "SIAULIAI_50_1_SQ_SOLDIER04", "", "");
		
		// Soldier Turan
		//-------------------------------------------------------------------------
		AddNpc(18, 20014, "Soldier Turan", "f_siauliai_50_1", -121.6255, 0.2093, -342.6637, -2, "SIAULIAI_50_1_SQ_SOLDIER05", "", "");
		
		// Soldier Ramos
		//-------------------------------------------------------------------------
		AddNpc(19, 20013, "Soldier Ramos", "f_siauliai_50_1", -247.3996, 0.2093, -383.0731, 90, "SIAULIAI_50_1_SQ_SOLDIER06", "", "");
		
		// Soldier Varan
		//-------------------------------------------------------------------------
		AddNpc(20, 20011, "Soldier Varan", "f_siauliai_50_1", -241.4549, 0.2093, -455.5384, 110, "SIAULIAI_50_1_SQ_SOLDIER07", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1517.925, 39.7087, -327.8859, -72, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1253.947, 39.7087, -430.2361, 27, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1249.79, 39.7087, -475.1338, 23, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1539.848, 39.7087, -329.6375, -67, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1241.167, 39.7087, -412.7715, 22, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(29, 147376, "", "f_siauliai_50_1", 1857.518, 22.2216, 470.0276, 266, "", "SIAULIAI50_FENCE01", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(36, 147376, "", "f_siauliai_50_1", 1884.561, 22.2216, 572.2065, 7, "", "SIAULIAI50_FENCE02", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(37, 147376, "", "f_siauliai_50_1", 1891.282, 22.2216, 429.4537, 173, "", "SIAULIAI50_FENCE03", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(38, 147376, "", "f_siauliai_50_1", 1991.031, 22.2216, 514.0597, -88, "", "SIAULIAI50_FENCE04", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(39, 147376, "", "f_siauliai_50_1", 1837.412, 22.2216, 720.3943, -88, "", "SIAULIAI50_FENCE05", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40, 147376, "", "f_siauliai_50_1", 1986.967, 22.2216, 721.7297, 90, "", "SIAULIAI50_FENCE07", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(41, 147376, "", "f_siauliai_50_1", 1879.878, 22.2216, 756.3043, 16, "", "SIAULIAI50_FENCE06", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(43, 20024, " ", "f_siauliai_50_1", 1868.28, 22.2216, 507.2224, 90, "SIAULIAI50_FENCE_BUILD01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(44, 20024, " ", "f_siauliai_50_1", 1920.902, 22.2216, 438.4957, 90, "SIAULIAI50_FENCE_BUILD03", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(45, 20024, " ", "f_siauliai_50_1", 1918.11, 22.2216, 561.4652, 90, "SIAULIAI50_FENCE_BUILD02", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46, 20024, " ", "f_siauliai_50_1", 1839.613, 22.2216, 696.5456, 90, "SIAULIAI50_FENCE_BUILD05", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47, 20024, " ", "f_siauliai_50_1", 1965.257, 22.2216, 685.0032, 90, "SIAULIAI50_FENCE_BUILD07", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(48, 20024, " ", "f_siauliai_50_1", 1903.923, 22.2216, 749.207, 90, "SIAULIAI50_FENCE_BUILD06", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(49, 20024, " ", "f_siauliai_50_1", 1978.54, 22.2216, 517.7938, 90, "SIAULIAI50_FENCE_BUILD04", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(50, 147376, "", "f_siauliai_50_1", 1857.966, 22.2216, 533.2983, 95, "", "SIAULIAI50_FENCE01_2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(51, 147376, "", "f_siauliai_50_1", 1955.001, 22.2216, 426.9849, 180, "", "SIAULIAI50_FENCE03_2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(52, 147376, "", "f_siauliai_50_1", 1838.656, 22.2216, 661.6422, 101, "", "SIAULIAI50_FENCE05_2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(53, 147376, "", "f_siauliai_50_1", 1941.446, 22.2216, 761.1147, -1, "", "SIAULIAI50_FENCE06_2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(54, 147376, "", "f_siauliai_50_1", 1979.971, 22.2216, 660.4097, 265, "", "SIAULIAI50_FENCE07_2", "");
		
		// Anti-Monster Proliferation Device
		//-------------------------------------------------------------------------
		AddNpc(55, 153025, "Anti-Monster Proliferation Device", "f_siauliai_50_1", 34.11184, -117.9135, 709.5142, 16, "", "SIAULIAI50_PLANT_BIGREPRESS_01", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1526.046, 39.7087, -347.6956, -70, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1340.77, 39.7087, -592.8141, 41, "SIAULIAI_50_WOOD_PIECE", "", "");
		
		// Wood
		//-------------------------------------------------------------------------
		AddNpc(22, 151031, "Wood", "f_siauliai_50_1", 1361.001, 39.7087, -606.4277, 38, "SIAULIAI_50_WOOD_PIECE", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", -47.93754, -117.9135, 787.2458, 51, "", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", -2.86829, -117.9135, 805.4315, 43, "", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", -34.38595, -117.9135, 863.3607, 61, "", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", 120.6212, -117.9135, 746.3159, 56, "", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", 174.6075, -117.9135, 771.8811, 51, "", "", "");
		AddNpc(67, 47200, " ", "f_siauliai_50_1", 153.6876, -117.9135, 852.46, 71, "", "", "");
		AddNpc(68, 147366, "", "f_siauliai_50_1", 2092.715, 22.2216, 551.6494, 90, "", "", "");
		AddNpc(69, 20026, "", "f_siauliai_50_1", 2096.839, 22.2216, 553.4232, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -133.1564, -117.9135, 279.7528, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -155.9245, -117.9135, 209.7504, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -312.2745, -117.9135, 193.9273, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -304.0715, -117.9135, 302.1412, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -352.699, -117.9135, 236.6722, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -517.106, -117.9135, 552.4959, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -391.2559, -117.9135, 559, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -455.1971, -117.9135, 523.108, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -438.3433, -117.9135, 572.0122, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -343.4162, -117.9135, 641.2315, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -334.9299, -117.9135, 727.4859, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", -258.387, -117.9135, 716.2117, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", 68.67037, -117.9135, 254.5482, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", 134.3549, -117.9135, 230.5264, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", 246.4288, -117.9135, 302.7638, 90, "", "", "");
		AddNpc(70, 47200, " ", "f_siauliai_50_1", 274.2707, -117.9135, 366.2958, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(71, 147376, "", "f_siauliai_50_1", 1951.65, 22.2216, 567.2253, -9, "", "SIAULIAI50_FENCE02_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(72, 20024, " ", "f_siauliai_50_1", 1902.218, 22.2216, 632.1721, 90, "SIAULIAI50_FENCE_BUILD08", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(73, 147376, "", "f_siauliai_50_1", 1911.585, 22.2216, 618.0828, 3, "", "SIAULIAI50_FENCE08", "");
		AddNpc(77, 147363, "Field Gen x", "f_siauliai_50_1", 146.7208, 0.2093, -410.2651, 90, "", "", "");
		AddNpc(77, 147363, "Field Gen x", "f_siauliai_50_1", -108.1805, 0.2093, -392.0951, 90, "", "", "");
		
		// Farm Worker
		//-------------------------------------------------------------------------
		AddNpc(79, 20118, "Farm Worker", "f_siauliai_50_1", 359.5833, 0.2093, -311.0488, -11, "SIAULIAI_50_1_SQ_MAN02", "", "");
		
		// Farm Worker
		//-------------------------------------------------------------------------
		AddNpc(80, 20138, "Farm Worker", "f_siauliai_50_1", 103.3357, 0.2093, -504.5117, 153, "SIAULIAI_50_1_SQ_MAN03", "", "");
		
		// Farm Worker
		//-------------------------------------------------------------------------
		AddNpc(82, 20151, "Farm Worker", "f_siauliai_50_1", 215.8972, 0.2093, -347.5767, 20, "SIAULIAI_50_1_SQ_MAN04", "", "");
		AddNpc(88, 20026, "", "f_siauliai_50_1", -82.74644, -117.9135, 482.8496, 90, "", "", "");
		AddNpc(89, 147362, "Field Gen x", "f_siauliai_50_1", 1593.643, 0.2092896, -1451.517, 90, "", "", "");
		AddNpc(89, 147362, "Field Gen x", "f_siauliai_50_1", 2271.084, 22.22157, 528.3769, 90, "", "", "");
		AddNpc(89, 147362, "Field Gen x", "f_siauliai_50_1", 897.9595, -43.96832, 1711.875, 90, "", "", "");
		AddNpc(89, 147362, "Field Gen x", "f_siauliai_50_1", -813.4186, -43.96832, 1662.486, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(90, 147392, "Lv1 Treasure Chest", "f_siauliai_50_1", -261.81, 0.31, -659.48, 90, "TREASUREBOX_LV_F_SIAULIAI_50_190", "", "");
		
		// Settler Rodonas
		//-------------------------------------------------------------------------
		AddNpc(91, 20138, "Settler Rodonas", "f_siauliai_50_1", 73.69281, -43.96832, 1504.9, -9, "SIAU501_RP_1_NPC", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(94, 147392, "Lv1 Treasure Chest", "f_siauliai_50_1", -1142.29, 0.31, -1366.83, 45, "TREASUREBOX_LV_F_SIAULIAI_50_194", "", "");
		
		// Narcon Prison
		//-------------------------------------------------------------------------
		AddNpc(95, 147507, "Narcon Prison", "f_siauliai_50_1", 17, 0, -1938, 90, "SIAULIAI_50_1_TO_PRISON_75_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(96, 152057, " ", "f_siauliai_50_1", 1921.32, 22.22, 497.09, 90, "HT3_SIAULIAI_50_1_SEED", "", "");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(97, 40080, "Warning", "f_siauliai_50_1", -27.03118, 0.21, -1732.657, 90, "FREE_DUNGEON_SIGN1", "TUTO_FREE_DUNGEON_CHECK", "");
		AddNpc(98, 20026, "", "f_siauliai_50_1", -61.97, -43.97, 1609.42, 90, "", "", "");
		AddNpc(99, 20026, " ", "f_siauliai_50_1", -135.8397, 0.2092896, -437.8788, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(100, 40095, " ", "f_siauliai_50_1", -745.8002, -146.3463, 581.8318, 90, "", "EXPLORER_MISLE48", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(101, 147469, " ", "f_siauliai_50_1", -934.0099, 0.2092896, -1468.608, 90, "", "Assistor_TUTO_04_TRACK", "");
	}
}
