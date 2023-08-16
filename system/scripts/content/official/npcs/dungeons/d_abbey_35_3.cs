//--- Melia Script ----------------------------------------------------------
// Elgos Monastery Annex
//--- Description -----------------------------------------------------------
// NPCs found in and around Elgos Monastery Annex.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DAbbey353NpcScript : GeneralScript
{
	public override void Load()
	{
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(1, 147311, "Black Note", "d_abbey_35_3", -1670.257, -7.629395E-06, -143.4527, 130, "JOB_PARDONER_6_1_NOTE01", "", "");
		
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(2, 147311, "Black Note", "d_abbey_35_3", 937.6669, -7.629395E-06, -236.0967, 110, "JOB_PARDONER_6_1_NOTE02", "", "");
		
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(3, 147311, "Black Note", "d_abbey_35_3", -75.60907, -7.629395E-06, 410.041, 60, "JOB_PARDONER_6_1_NOTE03", "", "");
		
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(4, 147311, "Black Note", "d_abbey_35_3", -161.9401, -7.950696E-06, 1005.897, 0, "JOB_PARDONER_6_1_NOTE04", "", "");
		
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(5, 147311, "Black Note", "d_abbey_35_3", -149.3166, 0.0004212946, 1360.426, 130, "JOB_PARDONER_6_1_NOTE05", "", "");
		
		// Black Note
		//-------------------------------------------------------------------------
		AddNpc(6, 147311, "Black Note", "d_abbey_35_3", 199.5686, -1.525879E-05, -151.6142, 120, "JOB_PARDONER_6_1_NOTE06", "", "");
		
		// Nahash Forest
		//-------------------------------------------------------------------------
		AddNpc(10, 40001, "Nahash Forest", "d_abbey_35_3", 20.79054, -7.629395E-06, 1662.704, 181, "", "ABBEY_35_3_SIAULIAI_35_1", "");
		AddNpc(11, 147364, "Field Gen x", "d_abbey_35_3", 20.07964, -7.629395E-06, 1663.287, 90, "", "", "");
		
		// Elgos Monastery Main Building
		//-------------------------------------------------------------------------
		AddNpc(12, 40001, "Elgos Monastery Main Building", "d_abbey_35_3", 11.03019, -95.33443, -1657.332, 0, "", "ABBEY_35_3_ABBEY_35_4", "");
		AddNpc(11, 147364, "Field Gen x", "d_abbey_35_3", -1.156526, -95.33443, -1655.763, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(13, 57681, " ", "d_abbey_35_3", -630.3427, -97.64734, 1201.207, 0, "ABBEY_35_3_HI_LOW", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(14, 156044, " ", "d_abbey_35_3", 824.8875, -85.04639, 553.5542, 90, "ABBEY_35_3_CURLING", "", "");
		AddNpc(15, 154005, " ", "d_abbey_35_3", -2140.859, -97.64735, 286.146, 90, "", "", "");
		AddNpc(16, 154005, " ", "d_abbey_35_3", 659.8414, -85.04652, 1061.788, 90, "", "", "");
		AddNpc(17, 154005, " ", "d_abbey_35_3", -993.2667, -97.64275, 906.876, 90, "", "", "");
		
		// Priest Dominikas
		//-------------------------------------------------------------------------
		AddNpc(20, 156000, "Priest Dominikas", "d_abbey_35_3", -264.628, -7.629395E-06, 919.7321, 90, "ABBEY_35_3_DOMINIKAS", "", "");
		
		// Villager Nella
		//-------------------------------------------------------------------------
		AddNpc(21, 20149, "Villager Nella", "d_abbey_35_3", -142.8859, -1.004465E-05, 907.2584, 270, "", "ABBEY_35_3_VILLAGE_A", "");
		
		// Villager Duncan
		//-------------------------------------------------------------------------
		AddNpc(22, 20154, "Villager Duncan", "d_abbey_35_3", -101.9074, -9.791572E-06, 867.472, 270, "", "ABBEY_35_3_VILLAGE_A", "");
		
		// Villager James
		//-------------------------------------------------------------------------
		AddNpc(23, 20138, "Villager James", "d_abbey_35_3", -99.7247, -7.846171E-06, 935.3561, 270, "", "ABBEY_35_3_VILLAGE_A", "");
		
		// Villager Nella
		//-------------------------------------------------------------------------
		AddNpc(24, 20149, "Villager Nella", "d_abbey_35_3", -183.5015, -7.823798E-06, 915.171, 45, "ABBEY_35_3_VILLAGE_A_2", "", "");
		
		// Villager Duncan
		//-------------------------------------------------------------------------
		AddNpc(25, 20154, "Villager Duncan", "d_abbey_35_3", -188.3174, -1.126113E-05, 846.6359, 90, "ABBEY_35_3_VILLAGE_B_2", "", "");
		
		// Villager James
		//-------------------------------------------------------------------------
		AddNpc(26, 20138, "Villager James", "d_abbey_35_3", -713.7778, -7.629395E-06, -149.7459, 0, "ABBEY_35_3_VILLAGE_C_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1655.377, -7.629395E-06, 78.09023, 61, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1622.069, -7.629395E-06, 59.52346, -68, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1624.911, -7.629395E-06, 93.63687, 39, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1643.822, -7.629395E-06, 90.08982, 51, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1604.887, -7.629395E-06, 85.75208, 28, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1615.145, -7.629395E-06, 69.31966, 103, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1609.262, -7.629395E-06, 49.27034, -47, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1601.611, -7.629395E-06, 76.34865, 90, "ABBEY_35_3_VINE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 156028, " ", "d_abbey_35_3", -1644.008, -7.629395E-06, 51.89185, 166, "ABBEY_35_3_VINE", "", "");
		
		// Suspicious Note
		//-------------------------------------------------------------------------
		AddNpc(28, 147312, "Suspicious Note", "d_abbey_35_3", -1661.652, -7.629395E-06, -220.5028, 90, "ABBEY_35_3_PAPER", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 40071, " ", "d_abbey_35_3", -1199.12, -7.629395E-06, -250.2417, 90, "", "ABBEY_35_3_DARK_WALL", "");
		
		// Priest Dominikas
		//-------------------------------------------------------------------------
		AddNpc(30, 156000, "Priest Dominikas", "d_abbey_35_3", -1292.605, -7.629395E-06, -245.8497, 270, "ABBEY_35_3_DOMINIKAS_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20025, " ", "d_abbey_35_3", -1266.687, -7.629395E-06, -78.29014, 90, "ABBEY_35_3_MAGIC", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 40071, " ", "d_abbey_35_3", 8.545988, -95.33443, -1444.908, 180, "", "ABBEY_35_3_DARK_WALL", "");
		
		// Priest Dominikas
		//-------------------------------------------------------------------------
		AddNpc(32, 156000, "Priest Dominikas", "d_abbey_35_3", -81.06805, -95.33443, -1209.138, 90, "", "ABBEY_35_3_DOMINIKAS_3", "");
		
		// Villager Nella
		//-------------------------------------------------------------------------
		AddNpc(33, 20149, "Villager Nella", "d_abbey_35_3", -5.526105, -95.33443, -1220.86, 270, "", "ABBEY_35_3_VILLAGE_B", "");
		
		// Villager Duncan
		//-------------------------------------------------------------------------
		AddNpc(34, 20154, "Villager Duncan", "d_abbey_35_3", -16.69177, -95.33443, -1267.858, 270, "", "ABBEY_35_3_VILLAGE_B", "");
		
		// Villager James
		//-------------------------------------------------------------------------
		AddNpc(35, 20138, "Villager James", "d_abbey_35_3", -2.464448, -95.33443, -1177.601, 270, "", "ABBEY_35_3_VILLAGE_B", "");
		
		// Elgos Monk
		//-------------------------------------------------------------------------
		AddNpc(36, 156025, "Elgos Monk", "d_abbey_35_3", -1584.205, -7.629395E-06, -106.7409, 90, "ABBEY_35_3_MONK", "", "");
		
		// Villager Nella
		//-------------------------------------------------------------------------
		AddNpc(37, 20149, "Villager Nella", "d_abbey_35_3", -1546.941, -7.629395E-06, -24.41688, 214, "", "ABBEY_35_3_VILLAGE_C", "");
		
		// Villager Duncan
		//-------------------------------------------------------------------------
		AddNpc(38, 20154, "Villager Duncan", "d_abbey_35_3", -1586.795, -7.629395E-06, -27.27802, 220, "", "ABBEY_35_3_VILLAGE_C", "");
		
		// Villager James
		//-------------------------------------------------------------------------
		AddNpc(39, 20138, "Villager James", "d_abbey_35_3", -1531.732, -7.629395E-06, 8.014847, 225, "", "ABBEY_35_3_VILLAGE_C", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -138.713, -7.629395E-06, -35.34511, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -238.2014, -7.629395E-06, -138.9903, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -234.2995, 0.01025077, -450.7866, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -294.6985, -7.629395E-06, -169.8849, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", 150.0242, -7.736352E-06, -95.57996, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", 213.7991, -1.525879E-05, -148.6914, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		AddNpc(42, 147364, "Field Gen x", "d_abbey_35_3", -53.84766, -7.686825E-06, 886.3211, 90, "", "", "");
		
		// Villager Duncan
		//-------------------------------------------------------------------------
		AddNpc(43, 20154, "Villager Duncan", "d_abbey_35_3", -12.32455, -7.629395E-06, -212.4398, 90, "ABBEY_35_3_VILLAGE_B_3", "", "");
		
		// ABBEY_35_3_SQ_4_TRIG
		//-------------------------------------------------------------------------
		AddNpc(44, 20026, "ABBEY_35_3_SQ_4_TRIG", "d_abbey_35_3", -12.82867, -7.629395E-06, -212.0605, 90, "", "ABBEY_35_3_SQ_4_PROG", "");
		AddNpc(45, 147362, "Field Gen x", "d_abbey_35_3", -12.43854, -7.629395E-06, -212.2385, 90, "", "", "");
		AddNpc(45, 147362, "Field Gen x", "d_abbey_35_3", -714.585, -7.629395E-06, -149.7987, 90, "", "", "");
		AddNpc(42, 147364, "Field Gen x", "d_abbey_35_3", -1609.363, -7.629395E-06, 36.92258, 90, "", "", "");
		AddNpc(42, 147364, "Field Gen x", "d_abbey_35_3", 0.9412079, 0.0001790779, 1279.437, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -37.89353, -7.629395E-06, -197.3682, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", 469.0435, 0.3416732, -225.7146, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", 957.6208, -7.629395E-06, -229.5294, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 156041, " ", "d_abbey_35_3", -992.2313, -7.629395E-06, -388.0436, 90, "ABBEY_35_3_SQ_11_EVILBILE", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(1000, 147392, "Lv1 Treasure Chest", "d_abbey_35_3", 565.98, 0.57, -317.33, 180, "TREASUREBOX_LV_D_ABBEY_35_31000", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(1001, 20025, "", "d_abbey_35_3", -1705, 0, -79, 90, "ABBEY353_HIDDENQ1_PREOBJ", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1003, 151018, " ", "d_abbey_35_3", -1584.018, -7, -106, 90, "", "ABBEY_35_4_SQ_8_PROG", "");
	}
}
