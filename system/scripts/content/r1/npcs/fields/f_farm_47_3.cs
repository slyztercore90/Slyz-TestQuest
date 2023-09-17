//--- Melia Script ----------------------------------------------------------
// Myrkiti Farm
//--- Description -----------------------------------------------------------
// NPCs found in and around Myrkiti Farm.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FFarm473NpcScript : GeneralScript
{
	public override void Load()
	{
		// Baron Allerno
		//-------------------------------------------------------------------------
		AddNpc(40001, "Baron Allerno", "f_farm_47_3", 1034.62, 56.88991, 90, "", "FARM_47_3_TO_FARM_47_4", "");
		
		// Aqueduct Bridge Area
		//-------------------------------------------------------------------------
		AddNpc(40001, "Aqueduct Bridge Area", "f_farm_47_3", -2181.688, 430.9418, -81, "", "FARM_47_3_TO_FARM_47_2", "");
		
		// Baron Secretary Arunas
		//-------------------------------------------------------------------------
		AddNpc(147405, "Baron Secretary Arunas", "f_farm_47_3", 741.5431, 222.3735, -44, "FARM47_ARUNAS");
		
		// Wizard Rimas
		//-------------------------------------------------------------------------
		AddNpc(147425, "Wizard Rimas", "f_farm_47_3", -525.8115, 615.8725, -14, "FARM47_RIMAS");
		
		// Baron Allerno
		//-------------------------------------------------------------------------
		AddNpc(155017, "Baron Allerno", "f_farm_47_3", -476.3035, 613.97, -45, "FARM47_BARON");
		
		// Baron Secretary Benius
		//-------------------------------------------------------------------------
		AddNpc(147404, "Baron Secretary Benius", "f_farm_47_3", -1906.904, 461.1358, 90, "FARM47_BENIUS");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153047, " ", "f_farm_47_3", -574.5868, 67.89838, 90, "FARM47_MAGIC01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153047, " ", "f_farm_47_3", -453.965, 822.3568, 90, "FARM47_MAGIC02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153047, " ", "f_farm_47_3", -1212.429, 491.6026, 90, "FARM47_MAGIC03");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153047, " ", "f_farm_47_3", -1210.073, -366.1025, 90, "FARM47_MAGIC04_D", "FARM47_MAGIC04_E");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47223, " ", "f_farm_47_3", -197.2945, 191.3628, 90, "FARM47_MAGIC_PRE");
		
		// Baron's Storage
		//-------------------------------------------------------------------------
		AddNpc(153043, "Baron's Storage", "f_farm_47_3", -92.98087, -501.2425, -34, "FARM47_HUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -180.4826, -60.54402, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -145.5753, -61.28939, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -162.8047, -34.01917, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -122.1187, -34.68272, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -184.8306, -0.3504105, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -145.2274, -3.360535, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -165.8963, 25.44341, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -123.2762, 22.36326, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -83.04091, -62.60612, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -49.60923, -61.37558, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -61.63684, -34.36629, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -25.63221, -31.86269, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -78.84135, -2.547316, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -44.38951, -7.418082, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -66.83349, 24.80557, 90, "FARM47_CROPS01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47201, " ", "f_farm_47_3", -27.72779, 23.67166, 90, "FARM47_CROPS01");
		
		// Detect strange aura
		//-------------------------------------------------------------------------
		AddNpc(147469, "Detect strange aura", "f_farm_47_3", -201.6524, 193.2753, 90, "", "FARM47_ODD_FEEL_E", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -458.8802, 13.59678, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_farm_47_3", -565.082, 828.1795, 90, "FARM47_BURY01");
		
		// Manticen appearance trigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "Manticen appearance trigger", "f_farm_47_3", -1901.595, 846.5129, 90, "", "FARM47_BOSS_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_farm_47_3", -202.5677, 186.8038, 90, "FARM47_MAGIC_PLACE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -778.079, 69.67455, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -860.9656, 278.5819, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -672.5386, -43.62386, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -567.5698, 156.0655, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -290.0813, 40.23779, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -187.4744, 135.1028, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", 3.040072, 8.304216, 90, "FARM47_PROTECT_GEM_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151002, " ", "f_farm_47_3", -864.5335, 440.5131, 90, "FARM47_PROTECT_GEM_1");
		
		// Lv3 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147393, "Lv3 Treasure Chest", "f_farm_47_3", -1311.72, 647.56, 90, "TREASUREBOX_LV_F_FARM_47_339");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_farm_47_3", -110.67, -508.38, 45, "TREASUREBOX_LV_F_FARM_47_3700");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_farm_47_3", -1759.567, 543.7935, 90, "", "EXPLORER_MISLE40", "");
	}
}
