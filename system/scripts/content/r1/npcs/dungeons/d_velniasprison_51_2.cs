//--- Melia Script ----------------------------------------------------------
// Demon Prison District 2
//--- Description -----------------------------------------------------------
// NPCs found in and around Demon Prison District 2.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DVelniasprison512NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kupole Arune
		//-------------------------------------------------------------------------
		AddNpc(154016, "Kupole Arune", "d_velniasprison_51_2", -93.1524, 553.9767, 0, "VPRISON512_MQ_NORGAILE");
		
		// Kupole Aldona
		//-------------------------------------------------------------------------
		AddNpc(154014, "Kupole Aldona", "d_velniasprison_51_2", 989.9536, -57.53646, 90, "VPRISON512_MQ_ALDONA");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 1105, -998, 90, "VELNIASP_512_GROUP_3_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 1187, -175, 90, "VELNIASP_512_GROUP_3_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 46, 448, 90, "VELNIASP_512_GROUP_2_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 421, 441, 90, "VELNIASP_512_GROUP_2_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 1056, 990, 90, "VELNIASP_512_GROUP_1_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_velniasprison_51_2", 1102, 1550, 90, "VELNIASP_512_GROUP_1_2");
		
		// Demon Prison District 1
		//-------------------------------------------------------------------------
		AddNpc(154000, "Demon Prison District 1", "d_velniasprison_51_2", 1123, 1884, 90, "VELNIASP512_TO_VELNIASP511");
		
		// Demon Prison District 3
		//-------------------------------------------------------------------------
		AddNpc(154000, "Demon Prison District 3", "d_velniasprison_51_2", 1458, 429, 90, "VELNIASP512_TO_VELNIASP513");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_velniasprison_51_2", 1041.867, 1709.221, 60, "WARP_D_VPRISON_51_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Tesla's Dedication
		//-------------------------------------------------------------------------
		AddNpc(147464, "Tesla's Dedication", "d_velniasprison_51_2", 1046.443, 1676.101, 90, "VPRISON512_STONE_01");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_velniasprison_51_2", -972.24, -460.24, 90, "TREASUREBOX_LV_D_VELNIASPRISON_51_225");
	}
}
