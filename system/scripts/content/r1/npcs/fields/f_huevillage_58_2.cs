//--- Melia Script ----------------------------------------------------------
// Vieta Gorge
//--- Description -----------------------------------------------------------
// NPCs found in and around Vieta Gorge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FHuevillage582NpcScript : GeneralScript
{
	public override void Load()
	{
		// Old Man of Andale Village
		//-------------------------------------------------------------------------
		AddNpc(147396, "Old Man of Andale Village", "f_huevillage_58_2", -186.69, -1570.87, 73, "HUEVILLAGE_58_2_MQ01_NPC");
		
		// Andale Village Priest
		//-------------------------------------------------------------------------
		AddNpc(147409, "Andale Village Priest", "f_huevillage_58_2", -239.14, -200.18, 73, "HUEVILLAGE_58_2_MQ02_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_huevillage_58_2", 58.31734, 653.9138, 90, "HUEVILLAGE_58_2_SQ01_NPC");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(151028, "Wood Sap Container", "f_huevillage_58_2", -89, 1399, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(151028, "Wood Sap Container", "f_huevillage_58_2", -243, 1305, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(151028, "Wood Sap Container", "f_huevillage_58_2", -345, 1134, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(151028, "Wood Sap Container", "f_huevillage_58_2", 83, 1278, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(147354, "Wood Sap Container", "f_huevillage_58_2", 181, 1363, 90, "HUEVILLAGE_58_2_MQ02_BUCKET02");
		
		// Ershike Altar
		//-------------------------------------------------------------------------
		AddNpc(147417, "Ershike Altar", "f_huevillage_58_2", -439, 234, 45, "HUEVILLAGE_58_2_MQ03_NPC");
		
		// Obelisk
		//-------------------------------------------------------------------------
		AddNpc(147414, "Obelisk", "f_huevillage_58_2", 859, 205, 20, "HUEVILLAGE_58_2_OBELISK_BEFORE");
		
		// Veja Ravine
		//-------------------------------------------------------------------------
		AddNpc(40001, "Veja Ravine", "f_huevillage_58_2", 439.58, -1641.15, 95, "", "HUEVILLAGE58_2_TO_HUEVILLAGE58_1", "");
		
		// Cobalt Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Cobalt Forest", "f_huevillage_58_2", 1461.54, 1157.1, 173, "", "HUEVILLAGE58_2_TO_HUEVILLAGE58_3", "");
		
		// Gravestone
		//-------------------------------------------------------------------------
		AddNpc(47192, "Gravestone", "f_huevillage_58_2", -254.08, 250.03, 91, "HUEVILLAGE_58_2_STORN01");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_huevillage_58_2", -515.8, -1541.66, 125, "WARP_F_HUEVILLAGE_58_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Obelisk
		//-------------------------------------------------------------------------
		AddNpc(147414, "Obelisk", "f_huevillage_58_2", 859, 205, 20, "", "HUEVILLAGE_58_2_OBELISK_AFTER", "");
		
		// JOB_PALADIN3_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_PALADIN3_1_TRIGGER", "f_huevillage_58_2", -686.4, -1179.39, 90, "", "JOB_PALADIN3_1_TRIGGER", "");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(40001, "Gytis Settlement Area", "f_huevillage_58_2", -390.231, -1617.554, -8, "", "HUEVILLAGE_58_2_SIAUL50_1", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_huevillage_58_2", -862, 203, 0, "TREASUREBOX_LV_F_HUEVILLAGE_58_248");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_huevillage_58_2", -159.95, -1274.28, 90, "TREASUREBOX_LV_F_HUEVILLAGE_58_249");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_huevillage_58_2", -836.0075, -1075.877, 90, "", "EXPLORER_MISLE21", "");
	}
}
