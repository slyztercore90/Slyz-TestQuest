//--- Melia Script ----------------------------------------------------------
// Mokusul Chamber
//--- Description -----------------------------------------------------------
// NPCs found in and around Mokusul Chamber.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdCatacomb382NpcScript : GeneralScript
{
	public override void Load()
	{
		// Laukyme Swamp
		//-------------------------------------------------------------------------
		AddNpc(40001, "Laukyme Swamp", "id_catacomb_38_2", 1229.425, -1377.15, 0, "", "CATACOMB_38_2_THORN_39_3", "");
		
		// Underground Grave of Ritinis
		//-------------------------------------------------------------------------
		AddNpc(40001, "Underground Grave of Ritinis", "id_catacomb_38_2", -1723.054, -1487.192, 270, "", "CATACOMB_38_2_CATACOMB_04", "");
		
		// Videntis Shrine
		//-------------------------------------------------------------------------
		AddNpc(40001, "Videntis Shrine", "id_catacomb_38_2", -12.98169, 2080.463, 180, "", "CATACOMB_38_2_CATACOMB_38_1", "");
		
		// Disciple Laius
		//-------------------------------------------------------------------------
		AddNpc(147482, "Disciple Laius", "id_catacomb_38_2", 1638.774, 141.474, 90, "CATACOMB_38_2_NPC_01");
		
		// Disciple Hones
		//-------------------------------------------------------------------------
		AddNpc(147486, "Disciple Hones", "id_catacomb_38_2", -377.7834, -1014.826, 90, "CATACOMB_38_2_NPC_02");
		
		// Hardened Astral Body Crystal
		//-------------------------------------------------------------------------
		AddNpc(151051, "Hardened Astral Body Crystal", "id_catacomb_38_2", -389.2628, 1460.534, 90, "CATACOMB_38_2_OBJ_01");
		
		// Kareras' Memoir
		//-------------------------------------------------------------------------
		AddNpc(47254, "Kareras' Memoir", "id_catacomb_38_2", -2431.969, -747.7094, 90, "CATACOMB_38_2_DIARY_01");
		
		// Records about Disciple Laius
		//-------------------------------------------------------------------------
		AddNpc(147311, "Records about Disciple Laius", "id_catacomb_38_2", -2357.178, -861.1367, 180, "CATACOMB_38_2_DIARY_02");
		
		// Records about Disciple Hones
		//-------------------------------------------------------------------------
		AddNpc(147311, "Records about Disciple Hones", "id_catacomb_38_2", -2016.992, -265.5501, 45, "CATACOMB_38_2_DIARY_03");
		
		// Finishing the research
		//-------------------------------------------------------------------------
		AddNpc(147312, "Finishing the research", "id_catacomb_38_2", -1865.796, -410.7773, 120, "CATACOMB_38_2_DIARY_04");
		
		// CATACOMB_38_2_SQ_06_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "CATACOMB_38_2_SQ_06_TRIGGER", "id_catacomb_38_2", -424.3834, -1427.868, 90, "", "CATACOMB_38_2_SQ_06_TRIGGER", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(151030, "Storage Box", "id_catacomb_38_2", 2404.445, 161.2741, -40, "CATACOMB_38_2_OBJ_02");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(151030, "Storage Box", "id_catacomb_38_2", 2421.691, -309.5009, -40, "CATACOMB_38_2_OBJ_02_EMPTY");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(151030, "Storage Box", "id_catacomb_38_2", 2347.812, -135.4374, 100, "CATACOMB_38_2_OBJ_02_EMPTY");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(151030, "Storage Box", "id_catacomb_38_2", 2211.666, -314.4012, 135, "CATACOMB_38_2_OBJ_02_EMPTY");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(151030, "Storage Box", "id_catacomb_38_2", 2262.9, 25.73061, 210, "CATACOMB_38_2_OBJ_02_EMPTY");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "id_catacomb_38_2", 265.5167, 1848.505, 0, "WARP_ID_CATACOMB_38_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// [Warlock Master]{nl}Melanie Melachim
		//-------------------------------------------------------------------------
		AddNpc(151069, "[Warlock Master]{nl}Melanie Melachim", "id_catacomb_38_2", 399.1917, 1812.767, 0, "WARLOCK_MASTER");
		
		// [Featherfoot Master]{nl}Kyoll Lurawa
		//-------------------------------------------------------------------------
		AddNpc(151070, "[Featherfoot Master]{nl}Kyoll Lurawa", "id_catacomb_38_2", 143.8976, 1882.239, 45, "FEATHERFOOT_MASTER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147311, " ", "id_catacomb_38_2", -1938.043, -843.6951, 270, "CATACOMB_38_2_HAUBERK_BOOK_1");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "id_catacomb_38_2", 1424.84, -371.59, 0, "TREASUREBOX_LV_ID_CATACOMB_38_21000");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151018, " ", "id_catacomb_38_2", -336.394, -214.0075, 90, "CATACOMB382_HIDDEN_GHOST");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", -532.1479, -645.5749, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", 290.18, -230, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", 173.13, -1077.57, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", 616.67, -612.51, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", 1261.48, -365.86, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20024, " ", "id_catacomb_38_2", 1507.8, -938.65, 90, "CATACOMB382_HIDDENQ1_SPIRIT");
		
		// Suspicious Device
		//-------------------------------------------------------------------------
		AddNpc(151108, "Suspicious Device", "id_catacomb_38_2", -90.39803, -1621.727, 45, "LOWLV_MASTER_ENCY_SQ_50");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147424, " ", "id_catacomb_38_2", -92.30838, -1491.193, 3, "LOWLV_MASTER_ENCY_SQ_50_DOLL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147424, " ", "id_catacomb_38_2", -216.1227, -1614.98, 88, "LOWLV_MASTER_ENCY_SQ_50_DOLL");
	}
}
