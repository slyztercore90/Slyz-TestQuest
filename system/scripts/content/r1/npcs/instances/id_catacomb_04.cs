//--- Melia Script ----------------------------------------------------------
// Underground Grave of Ritinis
//--- Description -----------------------------------------------------------
// NPCs found in and around Underground Grave of Ritinis.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdCatacomb04NpcScript : GeneralScript
{
	public override void Load()
	{
		// Mokusul Chamber
		//-------------------------------------------------------------------------
		AddNpc(40001, "Mokusul Chamber", "id_catacomb_04", -332.5004, -1978.717, 90, "", "CATACOMB_04_CATACOMB_38_2", "");
		
		// Videntis Shrine
		//-------------------------------------------------------------------------
		AddNpc(40001, "Videntis Shrine", "id_catacomb_04", 2267.073, 1353.261, 180, "", "CATACOMB_04_CATACOMB_38_1", "");
		
		// Istora Ruins
		//-------------------------------------------------------------------------
		AddNpc(40001, "Istora Ruins", "id_catacomb_04", -2243.331, -429.943, 235, "", "CATACOMB_04_REMAINS37_3", "");
		
		// Teleport Device
		//-------------------------------------------------------------------------
		AddNpc(147500, "Teleport Device", "id_catacomb_04", 3279.531, -948.3315, 225, "CATACOMB_04_SECRETOUT");
		
		// Magic Gem Fusion Device
		//-------------------------------------------------------------------------
		AddNpc(147475, "Magic Gem Fusion Device", "id_catacomb_04", -423.866, -1760.795, 90, "CATACOMB_04_OBJ_01");
		
		// Magic Field of Preservation
		//-------------------------------------------------------------------------
		AddNpc(154000, "Magic Field of Preservation", "id_catacomb_04", -1566, -756, 90, "CATACOMB_04_OBJ_02");
		
		// Barrier Stone
		//-------------------------------------------------------------------------
		AddNpc(147413, "Barrier Stone", "id_catacomb_04", 617, 1192, 90, "CATACOMB_04_OBJ_03");
		
		// Sealed Spatial Magic Gem
		//-------------------------------------------------------------------------
		AddNpc(151058, "Sealed Spatial Magic Gem", "id_catacomb_04", 1589, 861, 180, "CATACOMB_04_OBJ_04");
		
		// Black Shadow
		//-------------------------------------------------------------------------
		AddNpc(147469, "Black Shadow", "id_catacomb_04", -774, 952, 90, "CATACOMB_04_OBJ_05");
		
		// Teleport Device
		//-------------------------------------------------------------------------
		AddNpc(147500, "Teleport Device", "id_catacomb_04", 1395.222, -154.5499, 90, "CATACOMB_04_OBJ_06");
		
		// The Inheritance of the Master
		//-------------------------------------------------------------------------
		AddNpc(151052, "The Inheritance of the Master", "id_catacomb_04", 2918, -1596, 225, "CATACOMB_04_OBJ_07");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "id_catacomb_04", -126.31, 1200.43, -45, "TREASUREBOX_LV_ID_CATACOMB_041000");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "id_catacomb_04", 2068.551, 1249.537, 90, "HT_CATACOMB_04_SKULL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "id_catacomb_04", 2069.956, 1197.621, 90, "HT_CATACOMB_04_SKULL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "id_catacomb_04", 2071.464, 1151.012, 90, "HT_CATACOMB_04_SKULL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "id_catacomb_04", 2069.15, 973.76, 90, "HT_CATACOMB_04_SKULL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "id_catacomb_04", 2069.725, 885.4551, 90, "HT_CATACOMB_04_SKULL");
	}
}
